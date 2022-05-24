using System;
using UnityEngine;

namespace Utilities.Timer
{
    public class TimerHandle
    {
        public bool IsPaused { get; private set; }

        Action _callback;
        Action<TimerHandle> _internalCallback;

        public TimerHandle(float duration, ITimerUpdater updater, Action externalCallback, Action<TimerHandle> internalCallback)
        {
            RemainingTime = duration;
            updater.AddCallbackListener(Tick);
            _callback = externalCallback;
            _internalCallback = internalCallback;
        }

        public float RemainingTime { get; private set; }

        public void Tick(float deltaTime)
        {
            if(IsPaused)
            {
                return;
            }

            RemainingTime -= deltaTime;
            CheckForEndOfTimer();
        }

        private void CheckForEndOfTimer()
        {
            if (RemainingTime >= 0.0f)
            {
                return;
            }

            if(RemainingTime < 0.0f)
            {
                RemainingTime = 0.0f;
            }

            _callback();
            if (_internalCallback != null)
                _internalCallback(this);
        }

        public void CancelTimer()
        {
            IsPaused = true;

            if(_internalCallback != null)
                _internalCallback(this);
        }
        
        public void PauseTimer()
        {
            IsPaused = true;
        }

        public void ResumeTimer()
        {
            IsPaused = false;
        }
    }
}