using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    private GameObject shadow;
    //für späteren sound 
    //public AudioClip collectedSound;
    //private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //für späteren sound 
        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.playOnAwake = false;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //für späteren sound 
            //if (collectedSound != null)
            //{
            //    audioSource.PlayOneShot(collectedSound);
            //}


            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(shadow);
            Destroy(gameObject, 0.5f);
        }
    }

    public void SetShadow(GameObject shadowObject)
    {
        shadow = shadowObject;
    }
}
