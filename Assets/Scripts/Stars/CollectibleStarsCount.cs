using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStarsCount : MonoBehaviour
{
    TMPro.TMP_Text text;

    public int count = 0;

    public GameObject objToSetActive;
    public GameObject objToSetActiveTwo;

    //sorry 
    public GameObject skyeHelper1;
    public GameObject skyeHelper2;
    public GameObject skyeHelper3;
    
    public GameObject skye;
    private SkyeManager skyeManager;
    public Transform skyeRunTarget;
    public Transform enola;

    public bool countingEnabled = true;


    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        skyeManager = skye.GetComponent<SkyeManager>();

    }
    void Start() => UpdateCount();


    void OnEnable() => CollectibleStars.OnCollected += OnCollectibleCollected;
    void OnDisable() => CollectibleStars.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        if (countingEnabled)
        {
            count++;
            UpdateCount();
        }
    }

    public void EnableCount()
    {
        countingEnabled = true;
    }

    public void DisableCount()
    {
        countingEnabled = false;
    }

    void UpdateCount()
    {
        text.text = $"{count} / 25";

        if (count == 10)
        {
            objToSetActive.SetActive(true);
        }

        if (count == 12)
        {
            skyeManager.target = skyeRunTarget;
            skyeManager.EnableFollow();
            skyeHelper1.SetActive(true);
        }

        if (count == 13)
        {
            OnCollectibleCollected();
            skyeManager.target = enola;
        }

        if (count == 16)
        {
            skyeRunTarget.position = new Vector3(-5.74f, 1.44f, 0);
            skyeManager.target = skyeRunTarget;
            skyeHelper2.SetActive(true);
        }

        if (count == 17)
        {
            OnCollectibleCollected();
            skyeManager.target = enola;
        }

        if (count == 21)
        {
            skyeRunTarget.position = new Vector3(-6.89f, -4f, 0);
            skyeManager.target = skyeRunTarget;
            skyeHelper3.SetActive(true);
        }

        if (count == 22)
        {
            OnCollectibleCollected();
            skyeManager.target = enola;
        }

        if (count == 25)
        {
            objToSetActiveTwo.SetActive(true);
        }

    }

}
