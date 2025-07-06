using UnityEngine;

public class PlacingSkyeSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer skye;
    [SerializeField] private GameObject realSkye;  // <-- Referenz hier statt mit Find()

    [SerializeField] private Vector3 triggerLocation2;
    [SerializeField] private Vector3 triggerLocation3;

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
            skye.enabled = false;

        if (realSkye != null)
            realSkye.SetActive(true);  // <-- klappt jetzt auch wenn vorher deaktiviert
    }
}