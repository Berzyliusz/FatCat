using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerBahaviour : MonoBehaviour
{
    [SerializeField] private float _duration = 1.0f;
    [SerializeField] UnityEvent _onTimerEnd = new UnityEvent();

    private void Start()
    {
        
    }
}
