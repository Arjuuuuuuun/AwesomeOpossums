using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void onLevelComplete()
    {
        SceneManager.LoadScene(1);
    }

    public void onGameStart()
    {
        SceneManager.LoadScene(0);
    }

    public void onRestart()
    {
        SceneManager.LoadScene(2);
    }

    public void onLevelRestart()
    {
        switch (HeadManager.instance.level_counter)
        {
            case (1):
                HeadManager.instance.tutorial_counter = 0;
                break;

            case (2):
                HeadManager.instance.tutorial_counter = 5;
                break;

        }

        SceneManager.LoadScene(0);
    }

    public void onQuit()
    {
        Application.Quit();
    }
}
