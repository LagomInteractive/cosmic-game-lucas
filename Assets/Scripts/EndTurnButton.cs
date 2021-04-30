using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    public CosmicAPI api;
    public int cardNum = 0;
    private Vector3 clickPos;
    private bool clicked;
    public DeckController deckController;
    public void OnMouseDown()
    {
        deckController.DrawCard();
    }
}
