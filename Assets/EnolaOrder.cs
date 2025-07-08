using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnolaOrder : MonoBehaviour
{
    private void LateUpdate()
    {
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 10f) * -1;
    }
}
