using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterMenu : MonoBehaviour
{
    public void PlayGame()
    {
        ScoreManager.gameScene = false;
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenu()
    {
        ScoreManager.gameScene = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGAme()
    {
        Application.Quit();
    }

    public void ScoreMenu()
    {
        ScoreManager.gameScene = false;
        SceneManager.LoadScene("HighScoreScene");
    }

}
