using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string menuScene = "Menu";
    public string creditsScene = "Credit";

    // Reihenfolge der drei Level
    public string[] levelScenes =
    {
        "MainScene",
        "Next Level",
        "Level3"
    };

    public void StartGame()
    {
        SceneManager.LoadScene(levelScenes[0]);
    }

    public void NextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        int currentLevel = System.Array.IndexOf(levelScenes, currentScene);

        if (currentLevel < 0) return;

        if (currentLevel + 1 < levelScenes.Length)
        {
            SceneManager.LoadScene(levelScenes[currentLevel + 1]);
        }
        else
        {
            Credits();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void Credits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}