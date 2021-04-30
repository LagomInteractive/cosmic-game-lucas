using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public int[] hand = new int[0];
    public int cardDraw = 0;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnDraw();
        }

    }

    public void OnDraw()
    {
        
    }
}
