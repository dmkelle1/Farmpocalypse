using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    public int damage = 1;
    public bool destroyOnHit = true;
    public LayerMask whatStopsBullet; // optional mask (walls, enemies, etc.)

    float lifeTimer;

    void OnEnable()
    {
        lifeTimer = lifetime;
    }

    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f) gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        // check layer mask or always deactivate
        if (destroyOnHit)
        {
            gameObject.SetActive(false);
        }
    }

}