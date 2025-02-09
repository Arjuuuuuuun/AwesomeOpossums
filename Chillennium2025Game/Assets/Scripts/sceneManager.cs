using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneManager : MonoBehaviour
{

    private bool canInteract = true;
    // Starting Slides
    [SerializeField] Sprite slide1;
    [SerializeField] Sprite slide2;
    [SerializeField] Sprite slide3;
    [SerializeField] Sprite slide4;

    [SerializeField] Image slides;


    public void RunSlides()
    {
        canInteract = false;
        Sprite[] slidesArray = { slide1, slide2, slide3, slide4 };
        StartSlideShow(slidesArray);
    }

    private void StartSlideShow(Sprite[] slidesArray)
    {
        for (int i = 0; i < slidesArray.Length; i++)
        {
            slides.sprite = slidesArray[i];
            float startTime = Time.time;

            // Wait for at least 5 seconds and for spacebar press
            while (Time.time - startTime < 5f || !Input.GetKeyDown(KeyCode.Space))
            {
                // Do nothing (blocking loop until condition is met)
            }
        }

        // Enable interaction after all slides have been shown
        canInteract = true;
    }



    public void onQuit()
    {
        if (canInteract)
        {
            Debug.Log("You Quit the game");
            Application.Quit();
        }
    }

    public void pressStart()
    {
        if (canInteract)
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }

    public void returntoMenu()
    {
        if (canInteract)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void startLevel1()
    {
        if (canInteract)
        {
            SceneManager.LoadScene("TLevel1");
        }
    }
    public void startLevel2()
    {
        if (canInteract)
        {
            SceneManager.LoadScene("TLevel2");
        }
    }
    public void startLevel3()
    {
        if (canInteract)
        {
            SceneManager.LoadScene("TLevel3");
        }
    }

    public void startLevel4()
    {
        if (canInteract)
        {
            SceneManager.LoadScene("TLevel4");
        }
    }

    public void startLevelHoming()
    {
        if (canInteract)
        {
            SceneManager.LoadScene("LevelHoming");
        }
    }
}
