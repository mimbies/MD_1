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



    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();


    }
    void Start() => UpdateCount();


    void OnEnable() => CollectibleStars.OnCollected += OnCollectibleCollected;
    void OnDisable() => CollectibleStars.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();

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
            skye.GetComponent<SkyeManager>().followActive = true;
            skyeHelper1.SetActive(true);
            OnCollectibleCollected();
        }


        if (count == 16)
        {
            skye.GetComponent<SkyeManager>().followActive = false;
            skyeHelper2.SetActive(true);
            OnCollectibleCollected();
        }


        if (count == 21)
        {
            skye.GetComponent<SkyeManager>().followActive = true;
            skyeHelper3.SetActive(true);
            OnCollectibleCollected();
        }

        if (count == 25)
        {
            objToSetActiveTwo.SetActive(true);
        }

    }

}
