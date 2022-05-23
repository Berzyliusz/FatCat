using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Timer
{
    public class TimerExample : MonoBehaviour
    {
        [SerializeField] UnityEvent _onTimerEnd = null;
        [SerializeField] float _duration = 1.0f;

        void Start()
        {
            var handle = Timer.SetTimer(HandleTimerEnd, _duration);
        }

        void HandleTimerEnd()
        {
            _onTimerEnd?.Invoke();
        }
    }
}
