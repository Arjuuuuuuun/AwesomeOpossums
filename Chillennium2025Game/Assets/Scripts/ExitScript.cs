using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class ExitScript : MonoBehaviour

{
    string scene_name;
    int level_num = 0;
    private void Awake()
    {
        scene_name = SceneManager.GetActiveScene().name;
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
        if (scene_name == "TLevel4")
        {
            level_num = 3;
        }
    }
    // Detect collision with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            headManager.instance.level_completions[level_num] = 1;
            LoadMenu();
            Debug.Log("colission detected");
        }
    } 

    // Load the menu scene
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
