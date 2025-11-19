using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private bool gameOver;
    [SerializeField]
    private GameObject gameOverScreen;
    void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;
        gameOverScreen.SetActive(false);
    }

    public void EndGame()
    {
        gameOver = true;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
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
}
