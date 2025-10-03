using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text killsText;

    int kills = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        killsText.text = "KILLS: " + kills.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scoreIncrease()
    {
        kills += 1;
        killsText.text = "KILLS: " + kills.ToString();
    }
}
