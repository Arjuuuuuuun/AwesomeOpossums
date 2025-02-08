using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeToggler : MonoBehaviour
{
    [SerializeField] private Sprite Physical;
    [SerializeField] private Sprite Ghost;
    private Image image;
    private PlayerMovement player; // Reference to the player's script

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = Physical; // Default state

        // Find the player object (assuming it has the PlayerMovement script)
        player = FindObjectOfType<PlayerMovement>();

        if (player == null)
        {
            Debug.LogError("Player object with PlayerMovement script not found!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Check the player's `spectralOn` variable and switch sprite accordingly
            image.sprite = player.spectralOn ? Ghost : Physical;
        }
    }
}
