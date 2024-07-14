using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    [SerializeField] Portal _linkedTo;

    public Transform exitPoint => _exitPoint;
    [SerializeField] Transform _exitPoint;

    public float exitYRotation => _exitYRot;
    [SerializeField] float _exitYRot = 0;

    static float _portalDelay = 1f;

    static Dictionary<Rigidbody, float> _recentPortal = new Dictionary<Rigidbody, float>();

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Rigidbody rig)) {
            if (_recentPortal.ContainsKey(rig)) {
                if (Time.time - _recentPortal[rig] > _portalDelay) {
                    _recentPortal.Remove(rig);
                } else {
                    return;
                }
            }

            _recentPortal.Add(rig, Time.time);
            other.transform.position = _linkedTo.exitPoint.position;

            float rad = Mathf.Deg2Rad * _linkedTo.exitYRotation;
            other.transform.eulerAngles = new Vector3(0, rad, 0);
        }
    }

    private void OnDrawGizmos() {
        float rad = Mathf.Deg2Rad * _exitYRot;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)));
    }
}
