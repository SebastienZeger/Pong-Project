using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindow;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Pong");
        Time.timeScale = 1;
    }
    
    public void Settings()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingWindow()
    {
        settingsWindow.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
