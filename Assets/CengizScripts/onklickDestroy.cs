using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onklickDestroy : MonoBehaviour
{
    public float disappearSpeed = 1f;
    private bool isVisible = false;
    private bool isDisappearing = false;
    private Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;

    }

    void OnBecameVisible()
    {
        isVisible = true;
    }

    void OnBecameInvisible()
    {
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible && Input.GetButton("Submit"))
        {
            isDisappearing = true;
        }

        if (isDisappearing)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * disappearSpeed);

            if (transform.localScale.magnitude < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
