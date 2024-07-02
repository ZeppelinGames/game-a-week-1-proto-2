using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] float _infoDistance;
    [SerializeField] TextMeshPro _infoText;

    public enum WALL {
        NORTH,
        EAST,
        SOUTH,
        WEST
    };

    public struct DirRot {
        public Vector3 dir;
        public Vector3 rot;

        public DirRot(Vector3 dir, Vector3 rot) {
            this.dir = dir;
            this.rot = rot;
        }
    };

    private Dictionary<WALL, DirRot> _wallDirections = new Dictionary<WALL, DirRot>() {
        { WALL.NORTH, new DirRot(Vector3.forward, Vector3.zero) },
        { WALL.SOUTH,new DirRot( -Vector3.forward, Vector3.zero) },
        { WALL.EAST, new DirRot(Vector3.right, Vector3.zero) },
        { WALL.WEST, new DirRot(-Vector3.right, Vector3.zero) }
    };

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
