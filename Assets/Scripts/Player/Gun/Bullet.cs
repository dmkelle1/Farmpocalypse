using JetBrains.Annotations;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public PlayerStats playerStats;
    public float lifeTime = 2f;
    private float _damage = 100;
    float lifeTimer;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        lifeTimer = lifeTime;
    }
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) Destroy(gameObject);
    }
}
