using System;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    public TMP_Text killStatsText;
    public TMP_Text levelStatsText;
    public TMP_Text timeStatsText;

    public ScoreManager sm;

    public int kills;

    private float startTime = 0;
    private float currentTime;
    private bool timerActive = false;
    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        currentTime = startTime;
        timerActive = true;
    }

    private void Update()
    {
        if (timerActive) 
        {
            currentTime += Time.deltaTime;
            Debug.Log(currentTime);
        }
    }

    public void EndGame()
    {
        timerActive = false;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        killStatsText.text = "Kills: " + kills.ToString();
        levelStatsText.text = "Level: " + sm.level.ToString();
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeStatsText.text = "Time: " + string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
    }

    public void RetryButton()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void TitleButton()
    {
        SceneManager.LoadScene("Title Scene");
    }

    public void KillsIncrease()
    {
        kills += 1;
    }
}
