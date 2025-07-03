using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;

    public int count = 0;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }
    void Start() => UpdateCount();

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();

    }

    void UpdateCount()
    {
        text.text = $"{count} / 13";

    }
}
