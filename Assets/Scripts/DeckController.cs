using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    public CosmicAPI api;
    public HandManager handManager;
    public List<GameObject> cardDeck = new List<GameObject>();
    public int cardnumber = 0;
    

    public void OnCardDraw()
    {
        api.OnCard += (int id) =>
        {
            Debug.Log(id);
            Card card = api.GetCard(id);
            Debug.Log("I Just drew card " + card.name);
        };
    }

    public void DrawCard()
    {
        if (cardnumber < 5)
        {
            cardDeck[cardnumber].transform.position = handManager.hand[cardnumber].transform.position;
            cardDeck[cardnumber].transform.rotation = handManager.hand[cardnumber].transform.rotation;
            cardDeck[cardnumber].transform.Rotate(90f, 0f, 0f);
            cardDeck[cardnumber].transform.SetParent(handManager.hand[cardnumber]);
            cardDeck[cardnumber].GetComponent<DragableObject>().cardMoving = false;
            cardnumber += 1;
        }
        else
        {
            Debug.Log("Hand is full!");
        }
    }

    public void Update()
    {
        OnCardDraw();
    }
}
