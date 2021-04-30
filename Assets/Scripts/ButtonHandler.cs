using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject text;
    public GameObject kermit;
    public void StartGame()
    {
        kermit.gameObject.SetActive(true);
        text.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
