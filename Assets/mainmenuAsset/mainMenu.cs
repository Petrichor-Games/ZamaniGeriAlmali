using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("oyundan ciktik");
        Application.Quit();

    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
