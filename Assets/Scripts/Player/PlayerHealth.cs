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
        if(Health <= 0)
        {
            GameOverScript gos = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameOverScript>();
            gos.EndGame();
        }
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
