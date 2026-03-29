using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private string _sceneName = "Level 1";
    private string _sceneNameMenu = "MainMenu";

    public void NewGame()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(_sceneNameMenu);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_sceneName);
    }
}
