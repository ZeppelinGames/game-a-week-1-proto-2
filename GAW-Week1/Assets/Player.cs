using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _mouseSens = 5f;
    [SerializeField] Transform _camera;
    [SerializeField] Transform _rayIndicator;
    Rigidbody _rig;
    float h, v;

    //mouse 
    float x, y;

    // Start is called before the first frame update
    void Start() {
        _rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        x += Input.GetAxis("Mouse X") * _mouseSens;
        y += Input.GetAxis("Mouse Y") * _mouseSens;

        //this.transform.eulerAngles = new Vector3(0, y, 0);
        _camera.eulerAngles = new Vector3(y, x, 0);

        if (Physics.Raycast(transform.position, _camera.forward, out RaycastHit hit)) {
            _rayIndicator.position = hit.point;
        }
    }

    void FixedUpdate() {
        _rig.MovePosition(_rig.position + (new Vector3(h, 0, v) * Time.fixedDeltaTime * _moveSpeed));
    }
}
