using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    void Start()
    {
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
    }

    public void EndGame()
    {
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
