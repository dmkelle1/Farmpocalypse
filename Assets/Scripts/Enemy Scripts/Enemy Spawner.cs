using UnityEngine.Rendering;
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
    public int levelSpawn;

    void Start()
    {
        SetTimeUntilSpawn();
        levelSpawn = 1;
    }

    void Update()
    {
        _SpawnTime -= Time.deltaTime;
        if (_SpawnTime <= 0)
        {
            int templvl = levelSpawn;
            while (templvl > 0) 
            {
                spawnEnemy();
                templvl--;
            }
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

    //TODO create SortEnemies method
    //Look through all enemies that have been spawned
    //Sort them based on their Y position in relationship with the Player. 
    //This may require different order if they are above or below the player. 
    //If a Sprite's Sorting order is higher, it will appear in front of others. 
    //For reference -> https://discussions.unity.com/t/how-to-sort-sprites-of-different-objects-on-the-same-layer-ignoring-y-axis-in-a-top-down-game/1591531
    //This should be called every frame.

    public void spawnIncrease()
    {
        levelSpawn++;
    }
}
