using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    WorldCard wc;
    public CosmicAPI api;

    AttackLine line;

    private Vector3 mOffset;
    private float mZCoord;

    bool dragging = false;
    Vector3 start;

    private void Start() {
        wc = GetComponent<WorldCard>();
        line = GameObject.Find("AttackLine").GetComponent<AttackLine>();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world 
        Debug.Log(mousePoint);
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    private void OnMouseDown() {
        Minion minion = (Minion)api.GetCharacter(wc.GetMinionId());
        dragging = true;
        mOffset = transform.position - GetMouseAsWorldPoint();
        start = gameObject.transform.position;
    }

    Vector3 GetMousePosition() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(line.layermask);
        Physics.Raycast(ray, out hit, line.layermask);
        if (hit.collider) {

            return hit.transform.position;

        }
        return new Vector3();
    }

    private void OnMouseDrag() {
        if (dragging) {
            line.Draw(start, GetMouseAsWorldPoint() + mOffset);
        }
    }

    private void OnMouseUp() {
        dragging = false;
    }

    void Update() {

    }
}
