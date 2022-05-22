using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Timer
{
    public class TimerHandle
    {
        public bool IsPaused { get; private set; }

        private TimerHandleUpdater _updater = null;
        Action _callback;
        Action<TimerHandle> _internalCallback;

        public TimerHandle(float duration, TimerHandleUpdater updater, Action externalCallback, Action<TimerHandle> internalCallback)
        {
            RemainingTime = duration;
            _updater.AddCallbackListener(Tick);
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
            if (RemainingTime == 0.0f)
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

    public static class Timer
    {
        private static TimerHandleUpdater _updater;
        private static HashSet<TimerHandle> _timerHandles = new();

        public static void CancelAllTimers()
        {
             foreach(var handle in _timerHandles)
            {
                if(handle == null)
                {
                    continue;
                }
                handle.CancelTimer();
            }

            _timerHandles.Clear();
        }

        public static void PauseAllTimers()
        {

        }

        public static void ResumeAllTimers()
        {

        }

        public static TimerHandle SetTimer(Action callback, float duration)
        {
            if(_updater == null)
            {
                GameObject go = new GameObject("Timer Handle Updater");
                _updater = go.AddComponent<TimerHandleUpdater>();
            }

            TimerHandle handle = new(duration, _updater, callback, UnregisterHandle);
            _timerHandles.Add(handle);
            return handle;
        }

        public static void UnregisterHandle(TimerHandle handleToUnregister) => _timerHandles.Remove(handleToUnregister);
    }
}
