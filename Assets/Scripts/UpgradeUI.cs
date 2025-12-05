using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{

    public GameObject upgradePanel;
    public Button damageButton;
    public Button healthButton;
    public Button speedButton;
    public Button confirmButton;

    private System.Action pendingUpgrade;

    public PlayerStats playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upgradePanel.SetActive(false);
        confirmButton.gameObject.SetActive(false);
        confirmButton.onClick.AddListener(OnConfirmClicked);
    }


    private void OnEnable()
    {
        //reset scales 

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

        confirmButton.gameObject.SetActive(false);
        pendingUpgrade = null;
    }

    public void OnDamageChosen()
    {
        pendingUpgrade = () => playerStats.UpgradeDamage();
        ShowConfirmButton();
    }

    public void OnSpeedChosen()
    {
        pendingUpgrade = () => playerStats.UpgradeSpeed();
        ShowConfirmButton();
    }

    public void OnHealthChosen()
    {
        pendingUpgrade = () => playerStats.UpgradeHealth();
        ShowConfirmButton();
    }

    private void ShowConfirmButton()
    {
        confirmButton.gameObject.SetActive(true);
    }

    private void OnConfirmClicked()
    {
        if (pendingUpgrade != null)
        {
            pendingUpgrade.Invoke();
            pendingUpgrade = null;
        }

        confirmButton.gameObject.SetActive(false);
        CloseUpgradeChoices();
    }
}
