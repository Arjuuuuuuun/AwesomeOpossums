using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene loading

public class ExitScript : MonoBehaviour
{
    // Name of the menu scene to load
    public string menuSceneName = "Menu";

    // Detect collision with player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            LoadMenu();
            Debug.Log("colission detected");
        }
    }

    // Load the menu scene
    void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
