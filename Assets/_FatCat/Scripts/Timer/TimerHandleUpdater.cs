using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Timer
{
    public class TimerHandleUpdater : MonoBehaviour
    {
        public TimerHandle Handle { get; set; }

        List<Action<float>> _tickCallbacks = new();

        public void AddCallbackListener(Action<float> callback)
        {
            _tickCallbacks.Add(callback);
        }

        private void Update()
        {
            for(int i = 0; i < _tickCallbacks.Count; i++)
            {
                if(_tickCallbacks[i] == null)
                {
                    _tickCallbacks.RemoveAt(i);
                    i--;
                }

                _tickCallbacks[i](Time.deltaTime);
            }
        }
    }
}
