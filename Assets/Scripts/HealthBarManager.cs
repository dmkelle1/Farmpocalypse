using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Slider healthBar;
    //public TMP_Text hBText;
    public float maxHealth;
    public float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthBar.value = currentHealth;
        healthBar.maxValue = maxHealth;
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
    }
}
