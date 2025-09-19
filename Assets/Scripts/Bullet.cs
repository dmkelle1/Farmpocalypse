using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float lifeTime = 2f;
    public int damage = 1;
    float lifeTimer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
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
