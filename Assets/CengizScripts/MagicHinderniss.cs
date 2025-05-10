using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHinderniss : MonoBehaviour
{
    public string magicSchein = "MagicSchein";

    void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.CompareTag(magicSchein))
        {

            Destroy(gameObject);

        }
    }
}
