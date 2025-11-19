using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;

    public float damage;
    public float maxHealth;
    public float moveSpeed;

    public float baseDamage = 1f;
    public float baseSpeed = 1f;
    public float baseHealth = 1f;

    public float damagePerUpgrade = 1f;
    public float healthPerUpgrade = 20f;
    public float speedPerUpgrade = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = baseDamage;
        moveSpeed = baseSpeed;
        maxHealth = baseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeDamage()
    {
        damage += damagePerUpgrade;
        Debug.Log("Damage upgraded to: " + damage);
    }

    public void UpgradeSpeed()
    {
        moveSpeed += speedPerUpgrade;
        Debug.Log("Move speed upgraded to: " + moveSpeed);
    }

    public void UpgradeHealth()
    {
        maxHealth += healthPerUpgrade;
        Debug.Log("Max heath upgraded to: " + maxHealth);
    }
}
