using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void onLevelComplete()
    {
        SceneManager.LoadScene(2);
    }

    public void onGameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void onRestart()
    {
        SceneManager.LoadScene(0);
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

            case (3):
                HeadManager.instance.tutorial_counter = 12;
                break;

            case (4):
                HeadManager.instance.tutorial_counter = 15;
                break;

            case (5):
                HeadManager.instance.tutorial_counter = 17;
                break;

            case (6):
                HeadManager.instance.tutorial_counter = 21;
                break;

            case (7):
                HeadManager.instance.tutorial_counter = 23;
                break;
        }

        SceneManager.LoadScene(1);
    }

    public void onQuit()
    {
        Application.Quit();
    }
}
