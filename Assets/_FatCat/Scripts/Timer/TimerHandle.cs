using System;
using UnityEngine;

namespace Utilities.Timer
{
    public class TimerHandle
    {
        public bool IsPaused { get; private set; }

        Action _callback;
        Action<TimerHandle> _internalCallback;

        public TimerHandle(float duration, TimerHandleUpdater updater, Action externalCallback, Action<TimerHandle> internalCallback)
        {
            Debug.Log($"Creating timer: " + duration);
            RemainingTime = duration;
            updater.AddCallbackListener(Tick);
            _callback = externalCallback;
            _internalCallback = internalCallback;
        }

        public float RemainingTime { get; private set; }

        public void Tick(float deltaTime)
        {
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
            _internalCallback(this);
        }

        public void CancelTimer()
        {

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