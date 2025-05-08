using UnityEngine;

public class MoveWitch : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce = 5f; // Stärke des Sprungs

    void Start()
    {
        // Rigidbody-Komponente holen
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Wenn linke Maustaste oder Space gedrückt wird
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Setze Y-Geschwindigkeit auf 0, dann füge Impuls nach oben hinzu
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
