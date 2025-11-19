using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats ps;
    private float Health;
    [SerializeField]
    private Slider slider;

    void Start()
    {
        Health = ps.maxHealth;
    }

    void Update()
    {
        slider.value = Health;
        slider.maxValue = ps.maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        Debug.Log(damage);
        if(Health <= 0)
        {
            GameOverScript gos = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GameOverScript>();
            gos.EndGame();
        }
        slider.value = Health;
    }

    public void Heal(float heal)
    {
        Health += heal;
        if (Health > ps.maxHealth)
        {
            Health = ps.maxHealth;
        }
    }
}
