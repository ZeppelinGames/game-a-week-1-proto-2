using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {
    [SerializeField] Vector3 _rotateAxis;
    [SerializeField] float _rotateSpeed = 1;

    // Update is called once per frame
    void Update() {
        transform.eulerAngles += _rotateAxis * _rotateSpeed * Time.deltaTime;
    }
}
