using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    [SerializeField]
    private string gameStart;
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(gameStart);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
