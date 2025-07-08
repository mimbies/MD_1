using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CollectibleStars : MonoBehaviour
{
    public static event Action OnCollected;

    public GameObject objToSetActive;

    public CollectibleStarsCount Ccount;

    private AudioSource audioSource;


    public static int total = 0;


    void Awake() => total++;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collected star");
            OnCollected?.Invoke();



        }

    }


    void Update()
    {
        {

            if (Ccount.count == 10)
            {
                objToSetActive.SetActive(true);
            }

            



        }

    }
}
