using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _mouseSens = 5f;
    [SerializeField] Transform _camera;

    Rigidbody _rig;
    float h, v;

    //mouse 
    float x, y;


    // Start is called before the first frame update
    void Start() {
        _rig = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        x += Input.GetAxis("Mouse X") * _mouseSens;
        y -= Input.GetAxis("Mouse Y") * _mouseSens;

        _camera.eulerAngles = new Vector3(y, x, 0);
    }

    void FixedUpdate() {
        Vector3 desiredVelocity = new Vector3(h, 0, v) * _moveSpeed;
        Vector3 deltaVelocity = desiredVelocity - _rig.velocity;
        Vector3 moveForce = deltaVelocity * Time.fixedDeltaTime;
        _rig.AddForce(moveForce, ForceMode.Impulse);
    }
}
