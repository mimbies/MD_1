using UnityEngine;

public class onklickDestroy : MonoBehaviour
{
    public string inputButton = "Submit";
    public float disappearSpeed = 1f;

    private bool isVisible = false;
    private bool isDisappearing = false;
    private Vector3 originalScale;

    private Rigidbody2D rb;
    private Vector2 savedVelocity;

    void Start()
    {
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        savedVelocity = rb.velocity; // startgeschwindigkeit merken
    }

    void OnBecameVisible()
    {
        isVisible = true;
    }

    void OnBecameInvisible()
    {
        isVisible = false;
    }

    void Update()
    {
        if (isVisible && Input.GetButton(inputButton))
        {
            if (!isDisappearing)
            {
                savedVelocity = rb.velocity;
                rb.velocity = Vector2.zero;
            }

            isDisappearing = true;
        }
        else
        {
            if (isDisappearing && transform.localScale.magnitude > 0.01f)
            {
                rb.velocity = savedVelocity;
                isDisappearing = false;
            }
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
