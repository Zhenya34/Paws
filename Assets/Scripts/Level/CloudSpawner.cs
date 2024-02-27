using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab; // Префаб облака
    public Vector2 spawnAreaSize; // Размер области для генерации облаков
    public float minSpeed = 1f; // Минимальная скорость облаков
    public float maxSpeed = 3f; // Максимальная скорость облаков
    public Vector2 moveDirection = Vector2.left; // Направление движения облаков

    public float spawnInterval = 2f; // Интервал между созданием облаков
    private float nextSpawnTime; // Время следующего создания облака

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCloud();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnCloud()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(transform.position.x - spawnAreaSize.x / 2f, transform.position.x + spawnAreaSize.x / 2f),
            Random.Range(transform.position.y - spawnAreaSize.y / 2f, transform.position.y + spawnAreaSize.y / 2f)
        );

        GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
        float speed = Random.Range(minSpeed, maxSpeed);
        //newCloud.GetComponent<Cloud>().Initialize(moveDirection.normalized * speed);
    }
}