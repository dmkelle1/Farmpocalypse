using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public Slider expBar;
    private float currentExp;
    [SerializeField]
    private float maxExp = 100;
    public int level = 1;
    public UpgradeUI upgradeUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentExp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        expBar.value = currentExp;
        expBar.maxValue = maxExp;
        if (currentExp >= maxExp)
        {
            level += 1;
            currentExp -= maxExp;
            maxExp += 5;
            upgradeUI.ShowUpgradeChoices();
            EnemySpawner spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
            spawn.spawnIncrease();
            ScoreManager.Instance.scoreIncrease();
        }
    }

    public void ExpUp(float exp)
    {
        currentExp += exp;
    }
}
