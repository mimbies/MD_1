using UnityEngine;

public class FlappyWitchCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            FindObjectOfType<FlappyWitchMiniGameManager>().RestartGame();
        }
    }
}
