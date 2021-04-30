using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBehaviour : MonoBehaviour
{
    public Vector3 originalScale;
    private void Start()
    {
        originalScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse On!");
        gameObject.transform.localScale = originalScale * 1.2f;
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = originalScale;
    }

    private void OnMouseDown()
    {
        
    }
}
