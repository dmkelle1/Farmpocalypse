using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{

    public GameObject upgradePanel;
    public Button damageButton;
    public Button healthButton;
    public Button speedButton;

    public PlayerStats playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUpgradeChoices()
    {
        // Pause game if you want the world to stop during level up
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);
    }

    private void CloseUpgradeChoices()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnDamageChosen()
    {
        playerStats.UpgradeDamage();
        CloseUpgradeChoices();
    }

    public void OnSpeedChosen()
    {
        playerStats.UpgradeSpeed();
        CloseUpgradeChoices();
    }

    public void OnHealthChosen()
    {
        playerStats.UpgradeHealth();
        CloseUpgradeChoices();
    }
}
