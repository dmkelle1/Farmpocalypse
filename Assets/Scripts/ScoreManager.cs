using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text levelText;

    int level = 1;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        levelText.text = "Level: " + level.ToString();
    }

    public void scoreIncrease()
    {
        level += 1;
        levelText.text = "Level: " + level.ToString();
    }
}
