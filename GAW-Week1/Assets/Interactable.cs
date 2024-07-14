using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour {
    [SerializeField] UnityEvent _onInteractEvent;

    public virtual void Interact() {
        _onInteractEvent?.Invoke();
    }
}
