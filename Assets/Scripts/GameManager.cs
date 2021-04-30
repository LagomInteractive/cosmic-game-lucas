using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CosmicAPI api;
    public Canvas canvas;
    public GameObject cardPrefab;
    public Transform cardsSpawn;
    public GameObject deckController;
    public Transform deckParent;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        api.OnEverythingLoaded += () =>
        {
            // Load all cards
            Card[] cards = api.GetCards();

            for (int i = 0; i < 10; i++)
            {
                Card card = cards[i];
                Transform testCard = api.InstantiateWorldCard(card.id, deckParent).transform;
                deckController.GetComponent<DeckController>().cardDeck.Add(testCard.gameObject);
                testCard.GetComponent<DragableObject>().id = i;
                testCard.GetComponent<DragableObject>().api = api;
            }
        };
    }
}
