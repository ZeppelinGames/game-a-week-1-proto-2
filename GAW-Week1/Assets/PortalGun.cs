using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour {
    [SerializeField] Transform _camera;
    [SerializeField] Transform _rayIndicator;
    [SerializeField] MeshRenderer _indicatorMesh;
    [SerializeField] float _indicatorSize = 0.1f;
    [SerializeField] float _interactDistance;
    [SerializeField] Color _interactColour;
    [SerializeField] Color _nonInteractColour;

    [Header("Portals")]
    [SerializeField] Transform _bluePortal;
    [SerializeField] Transform _orangePortal;


    const string NoPortalTag = "NoPortal";
    bool _hasPortalGun;

    // Update is called once per frame
    void Update() {
        if (Physics.Raycast(transform.position, _camera.forward, out RaycastHit hit)) {
            _rayIndicator.position = hit.point;
            _rayIndicator.localScale = Vector3.one * _indicatorSize * hit.distance;

            bool canInteract = hit.distance < _interactDistance;
            _indicatorMesh.material.color = canInteract ? _interactColour : _nonInteractColour;

            if (Input.GetKeyDown(KeyCode.E)) {
                if (hit.transform.TryGetComponent(out Interactable interact) && canInteract) {
                    interact.Interact();
                }
            }

            if (_hasPortalGun) {
                if (Input.GetMouseButtonDown(0)) {
                    PlacePortal(_bluePortal, hit);
                }
                if (Input.GetMouseButtonDown(1)) {
                    PlacePortal(_orangePortal, hit);
                }
            }
        }
    }

    void PlacePortal(Transform portal, RaycastHit hit) {
        if (hit.transform.CompareTag(NoPortalTag)) {
            return;
        }

        portal.transform.position = hit.point;
        portal.transform.forward = -hit.normal;
    }

    public void GivePortalGun() {
        _hasPortalGun = true;
    }
}
