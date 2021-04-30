using System;
using System.Collections;

using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
public class DragableObject : MonoBehaviour
{
    private Vector3 mOffset;
    private Vector3 originalPos;
    private float mZCoord;
    private RaycastHit hit;
    private Vector3 scaleChange;
    public CosmicAPI api;

    private float lastPos;
    public float cardSpeed;
    public float cardRotation;
    public bool cardMoving = false;
    public int id;

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
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        originalPos = gameObject.transform.position;
    }
    void OnMouseDrag()
    {
        transform.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
            }
            transform.position = GetMouseAsWorldPoint() + mOffset;
    }
    private void OnMouseUp()
    {
        Debug.Log(hit.collider);
        if (hit.collider == null)
        {
            StartCoroutine(MoveOverSeconds(gameObject, originalPos, 0.5f));
            transform.gameObject.layer = LayerMask.NameToLayer("Default");
        }
        else if (hit.collider.tag == "Board")
        {
            Debug.Log("Played Minion");
            scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
            gameObject.transform.SetParent(hit.transform);
            gameObject.transform.position = hit.transform.position;
            gameObject.transform.rotation = hit.transform.rotation;
            gameObject.transform.Rotate(90f, 0f, 0f);
            gameObject.transform.localScale = scaleChange;
            transform.gameObject.layer = LayerMask.NameToLayer("Default");
            FindObjectOfType<BoardController>().AddToBoard(gameObject);
            Debug.Log("Dragable again");
        }
        else if (hit.collider.tag != "Board")
        {
            StartCoroutine(MoveOverSeconds(gameObject, originalPos, 0.5f));
            transform.gameObject.layer = LayerMask.NameToLayer("Default");
        }
        
    }

    void RotateOnMove()
    {
        cardRotation = cardSpeed * 50;
        Mathf.Clamp(cardRotation, -40, 40);
        Quaternion target = Quaternion.Euler(0, 0, cardRotation);
        transform.rotation  = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
    }
    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame ();
        }
    }
    public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        cardMoving = false;
    }
}