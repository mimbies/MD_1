using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonPuzzle : MonoBehaviour
{
    public int buttonID;
    private bool isPressed = false;
    private SpriteRenderer sr;
    private ButtonManger manager;
    private Color originalColor;

    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        manager = FindObjectOfType<ButtonManger>();
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetButton()
    {
        isPressed = false;
        StartCoroutine(FlashRedThenReset());
    }
    private IEnumerator FlashRedThenReset()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        sr.color = Color.red;
        yield return new WaitForSeconds(1f);

        if (col != null) col.enabled = true;
        sr.color = originalColor;

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (isPressed) return;

        if (other.CompareTag("Player"))
        {

            isPressed = true;

            audioSource.Play();

            sr.color = originalColor * 0.5f;

            manager.ButtonPressed(buttonID);
        }

    }

    public void SetColor(Color color)
    {
        sr.color = color;
    }

}
