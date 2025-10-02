using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyIdentity;
    public float minSpawnTime; //minimum amount of time in between spawns
    public float maxSpawnTime; //maximum amount of time in between spawns
    private float _SpawnTime; //Time for spawn
    private Vector2 spawnPosition;
    [SerializeField]
    private float _minX, _maxX, _minY, _maxY; //Determine Position for spawning
    [SerializeField]
    private float _thresholdDistance = 1f;
    private Vector2 _player;

    void Start()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        _SpawnTime -= Time.deltaTime;
        if (_SpawnTime <= 0)
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        RandomLocationGeneration();
        Instantiate(enemyIdentity, spawnPosition, Quaternion.identity);
        SetTimeUntilSpawn();
    }
    void SetTimeUntilSpawn()
    {
        _SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void RandomLocationGeneration()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distance = 0;
        while (spawnPosition == null || distance <= _thresholdDistance) {
            float randomX = Random.Range(_minX, _maxX);
            float randomY = Random.Range(_minY, _maxY);
            spawnPosition = new Vector2(randomX, randomY);
            distance = Vector2.Distance(_player, spawnPosition);
        }
        
    }
}
