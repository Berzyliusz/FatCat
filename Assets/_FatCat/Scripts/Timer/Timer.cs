using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Timer
{
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

            Debug.Log($"Creating timer for {duration}");
            TimerHandle handle = new(duration, _updater, callback, UnregisterHandle);
            _timerHandles.Add(handle);
            return handle;
        }

        private static void UnregisterHandle(TimerHandle handleToUnregister) => _timerHandles.Remove(handleToUnregister);
    }
}
