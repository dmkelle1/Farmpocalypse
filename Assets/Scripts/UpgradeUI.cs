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

        damageButton.onClick.AddListener(OnDamageChosen);
        //healthButton.onClick.AddListener(OnHealthChosen);
        speedButton.onClick.AddListener(OnSpeedChosen);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Call the function for the action you want to perform
            ShowUpgradeChoices();
        }
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

    private void OnDamageChosen()
    {
        playerStats.UpgradeDamage();
        CloseUpgradeChoices();
    }

    private void OnSpeedChosen()
    {
        playerStats.UpgradeSpeed();
        CloseUpgradeChoices();
    }
}
