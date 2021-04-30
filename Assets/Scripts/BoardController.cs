using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class BoardController : MonoBehaviour
{
    public List<GameObject> playerBoard = new List<GameObject>();
    public List<GameObject> enemyBoard = new List<GameObject>();

    public void AddToBoard(GameObject gameObject)
    {
        playerBoard.Add(gameObject);
        BoardPlacement();
    }

    public void Update()
    {
        
    }

    public void BoardPlacement()
    {
        for (int i = 0; i < playerBoard.Count; i++)
        {
            playerBoard[i].transform.position = new Vector3((playerBoard[i].transform.parent.position.x + (2 * i)), playerBoard[i].transform.parent.position.y, playerBoard[i].transform.parent.position.z);
        }
    }
}
