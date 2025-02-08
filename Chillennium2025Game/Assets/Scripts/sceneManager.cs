using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void onQuit()
    {
        Debug.Log("You Quit the game");
        Application.Quit();
    }

    public void pressStart()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void returntoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
