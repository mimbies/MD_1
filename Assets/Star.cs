using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    private GameObject shadow;


    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (audioSource)
            {
                audioSource.Play();
            }



            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(shadow);
            Destroy(gameObject, audioSource.clip.length);
        }
    }

    public void SetShadow(GameObject shadowObject)
    {
        shadow = shadowObject;
    }
}
