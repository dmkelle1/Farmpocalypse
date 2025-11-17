using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    private float attackDamage = 1f;
    [SerializeField]
    private float attackCooldown = 1f;
    private float attackTime = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null && attackTime <= 0f) 
        {
            player.TakeDamage(attackDamage);
            attackTime = attackCooldown;
        }
    }

    void Update()
    {
        attackTime -= Time.deltaTime;
    }
}
