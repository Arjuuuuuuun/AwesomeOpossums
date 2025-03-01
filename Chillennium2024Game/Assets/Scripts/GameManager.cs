using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void onQuit()
    {
        Debug.Log("You Quit the game");
        Application.Quit();
    }
    public void onWin()
    {
        SceneManager.LoadScene("You Won");
    }
    public void onGameStart() //Also the same as restart game
    {
        SceneManager.LoadScene("Game Scene");
        HeadManager.instance.level_counter = 0;
        HeadManager.instance.text_counter = 0;
    }
    public void onGameRetry()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void NextLevel()
    {
        GameObject.Find("TextManager").SendMessage("StartWave");
        GameObject.Find("Spawner").GetComponent<Spawner>().SendMessage("StartLevel", HeadManager.instance.level_counter);
    }

}
