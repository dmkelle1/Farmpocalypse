using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyIdentity;
    public float minSpawnTime; //minimum amount of time in between spawns
    public float maxSpawnTime; //maximum amount of time in between spawns
    private float SpawnTime; //Time for spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime <= 0)
        {
            Instantiate(enemyIdentity, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    void SetTimeUntilSpawn()
    {
        SpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
