using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void startLevel1()
    {
        
            SceneManager.LoadScene("TLevel1");
        
    }
    public void startLevel2()
    {
      
            SceneManager.LoadScene("TLevel2");
        
    }
    public void startLevel3()
    {
      
            SceneManager.LoadScene("TLevel3");
        
    }

    public void startLevel4()
    {
         SceneManager.LoadScene("TLevel4");
        
    }

    public void startLevelConga()
    {
        SceneManager.LoadScene("LevelConga");
    }

    public void startLevelVertical()
    {
        SceneManager.LoadScene("MediumLevel1");
    }

    public void startLevelMaze()
    {
        SceneManager.LoadScene("LevelMaze");
    }

    public void startLevelKeyHunt()
    {
        SceneManager.LoadScene("LevelKeyHunt");
    }

    public void startLevelGrid()
    {
        SceneManager.LoadScene("LevelGrid");
    }

    public void startLevelLines()
    {
        SceneManager.LoadScene("LevelWaterfall");
    }

    public void startLevelHoming()
    {       
        SceneManager.LoadScene("LevelHoming");       
    }
}
