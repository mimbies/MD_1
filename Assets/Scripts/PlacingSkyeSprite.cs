using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingSkyeSprite : MonoBehaviour
{
    [SerializeField] public SpriteRenderer skye;

    [SerializeField] public Vector3 triggerLocation2;
    [SerializeField] public Vector3 triggerLocation3;
    public void MoveSkyeToTrigger2()
    {
        if (skye != null)
        {
            skye.transform.position = triggerLocation2;
        }
    }

    public void MoveSkyeToTrigger3()
    {
        if (skye != null)
        {
            skye.enabled = false;
        }
    }
}
