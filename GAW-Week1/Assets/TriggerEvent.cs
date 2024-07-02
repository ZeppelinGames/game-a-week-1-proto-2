using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent _onTriggerEnter;
    [SerializeField] bool _triggerOnce;

    bool _triggered;

    private void OnTriggerEnter(Collider other) {
        if (_triggerOnce && _triggered) {
            return;
        }

        if (other.CompareTag("Player")) {
            _triggered = true;
            _onTriggerEnter?.Invoke();
        }
    }
}
