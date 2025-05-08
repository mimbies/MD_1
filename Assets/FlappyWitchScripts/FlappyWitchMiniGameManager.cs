using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyWitchMiniGameManager : MonoBehaviour
{
    [Header("Obstacle Settings")]
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float destroyX = -15f;

    [Header("Spawning Settings")]
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Vector2 heightRange = new Vector2(-2f, 2f);
    [SerializeField] private float spawnX = 10f;
    [SerializeField] private int totalObstaclesToSpawn = 10;

    [Header("Scene Settings")]
    [SerializeField] private string nextSceneName = "NextScene"; // Replace with actual scene name

    private float timer;
    private int spawnedCount = 0;
    private int passedCount = 0;
    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval && spawnedCount < totalObstaclesToSpawn)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomY = Random.Range(heightRange.x, heightRange.y);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0f);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        // Add movement and scoring behavior
        obstacle.AddComponent<MoveAndScore>().Init(moveSpeed, destroyX, this);
        spawnedCount++;
    }

    public void RegisterPassedObstacle()
    {
        passedCount++;
        if (passedCount >= totalObstaclesToSpawn && !gameEnded)
        {
            gameEnded = true;
            LoadNextScene();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    // Inner class for obstacle movement and scoring
    private class MoveAndScore : MonoBehaviour
    {
        private float speed;
        private float destroyX;
        private FlappyWitchMiniGameManager manager;
        private bool hasPassed = false;

        public void Init(float moveSpeed, float destroyPoint, FlappyWitchMiniGameManager gameManager)
        {
            speed = moveSpeed;
            destroyX = destroyPoint;
            manager = gameManager;
        }

        void Update()
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (!hasPassed && transform.position.x < -5)
            {
                hasPassed = true;
                manager.RegisterPassedObstacle();
            }

            if (transform.position.x < destroyX)
                Destroy(gameObject);
        }
    }
}
