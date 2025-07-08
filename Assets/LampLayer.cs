using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder;
    }
}
