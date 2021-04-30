using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLine : MonoBehaviour {
    LineRenderer line;
    public LayerMask layermask;
    void Start() {
        line = GetComponent<LineRenderer>();
    }

    public void Draw(Vector2 start, Vector2 end) {
        line.SetPosition(0, new Vector3(start.x, start.y, 0));
        line.SetPosition(1, new Vector3(end.x, end.y, 0));
    }

    void Update() {

    }
}
