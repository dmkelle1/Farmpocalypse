using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    private float Health;
    [SerializeField]
    private HealthBarManager hBM;
    void Start()
    {
        hBM.SetMaxHealth(MaxHealth);
        Health = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        hBM.SetHealth(Health);
    }

    public void Heal(float heal)
    {
        Health += heal;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        hBM.SetHealth(Health);
    }
}
