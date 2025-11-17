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

    private void Update()
    {
        if (gameOver) 
        { 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                string sceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    public void EndGame()
    {
        gameOver = true;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }
}
