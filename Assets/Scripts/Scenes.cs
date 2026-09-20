using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void StartPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("GameWin");
    }

    public void LooseGame()
    {
        SceneManager.LoadScene("GameLoose");
    }

    public void GoToPreferences()
    {
        SceneManager.LoadScene("Preferences");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        // Only works in Windows build
        Application.Quit();
    }
}
