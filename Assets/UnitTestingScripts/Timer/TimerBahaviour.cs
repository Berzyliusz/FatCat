using UnityEngine;
using UnityEngine.Events;

public class TimerBahaviour : MonoBehaviour
{
    [SerializeField] private float _duration = 1.0f;
    [SerializeField] UnityEvent _onTimerEnd = new UnityEvent();

    private Timer _timer = null;

    private void Start()
    {
        _timer = new Timer(_duration);
        _timer.OnTimerEnd += HandleTimerEnd;
    }

    private void HandleTimerEnd()
    {
        _onTimerEnd?.Invoke();

        Destroy(this);
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);
    }
}
