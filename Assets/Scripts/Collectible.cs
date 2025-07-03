using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using System;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;

    public bool collectingAllowed = false;


    public static int total = 0;


    void Awake() => total++;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collecting allowed");

            collectingAllowed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collecting forbidden");
            collectingAllowed = false;
        }
    }

    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space) && collectingAllowed)
            {
                Debug.Log("Detected KeyInput");
                OnCollected?.Invoke();
                Destroy(this.gameObject);

            }



        }

    }
}
