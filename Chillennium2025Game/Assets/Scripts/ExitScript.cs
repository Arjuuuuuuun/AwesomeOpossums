using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class ExitScript : MonoBehaviour

{
    string scene_name;
    int level_num = 0;
    audioManager audioManager;
    private void Awake()
    {

        audioManager = FindObjectOfType<audioManager>();
        scene_name = SceneManager.GetActiveScene().name;
        Debug.Log(scene_name);
        if (scene_name == "TLevel1")
        {
            level_num = 0;
        }
        if (scene_name == "TLevel2")
        {
            level_num = 1;
        }
        if (scene_name == "TLevel3")
        {
            level_num = 2;
        }
        if (scene_name == "Tlevel4")
        {
            level_num = 3;
        }
        if (scene_name == "LevelMaze")
        {
            level_num = 4;  
        }
        if (scene_name == "LevelConga")
        {
            level_num = 5;
        }
        if (scene_name == "MediumLevel1")
        {
            level_num = 6;
        }
        if (scene_name == "LevelGrid")
        {
            level_num = 7;
        }
        if (scene_name == "LevelHoming")
        {
            level_num = 8;
        }
        if (scene_name == "LevelWaterfall")
        {
            level_num = 9;
        }
        if (scene_name == "LevelKeyHunt")
        {
            level_num = 10;
        }
    }
    // Detect collision with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            headManager.instance.level_completions[level_num] = 1;
            Debug.Log(level_num);
            StartCoroutine("LoadMenuScene");
            Debug.Log("colission detected");
        }
    } 

    // Load the menu scene
    private void LoadMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    IEnumerator LoadMenuScene()
    {
        audioManager.SendMessage("playWinSound");
        yield return new WaitForSeconds(1f);
        LoadMenu();
    }
}
