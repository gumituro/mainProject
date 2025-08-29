using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    public void RestartGame()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene("MainMenu");
    }

    /*
    public void QuitGame()
    {
        Application.Quit();
    }*/
}