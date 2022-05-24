using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Timer
{
    public interface ITimerUpdater
    {
        public void Tick(float delta);
        public void AddCallbackListener(Action<float> callback);
    }

    public class TimerHandleUpdater : MonoBehaviour, ITimerUpdater
    {
        public TimerHandle Handle { get; set; }

        List<Action<float>> _tickCallbacks = new();

        public void AddCallbackListener(Action<float> callback)
        {
            _tickCallbacks.Add(callback);
        }

        private void Update()
        {
            Tick(Time.deltaTime);
        }

        public void Tick(float delta)
        {
            for (int i = 0; i < _tickCallbacks.Count; i++)
            {
                if (_tickCallbacks[i] == null)
                {
                    _tickCallbacks.RemoveAt(i);
                    i--;
                }
                _tickCallbacks[i](delta);
            }
        }
    }
}
