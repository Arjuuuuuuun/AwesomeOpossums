using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxEnergy = 100f;
    public bool state = false; // False = normal, True = night vision
    public float energyDrainRate = 5f; // Energy drains per second when in night vision mode
    public Slider energyBar; // Assign in the Inspector

    private Rigidbody2D rb;
    private Vector2 movement;
    private float currentEnergy;
    delegate void toggleOnSight();


    void Start()
    {
        state = false;
        rb = GetComponent<Rigidbody2D>();
        currentEnergy = maxEnergy;

        if (energyBar != null)
            energyBar.maxValue = maxEnergy;
    }

    void Update()
    {
        // Toggle night vision mode with Spacebar (only if energy > 0)
        if (Input.GetKeyDown(KeyCode.Space) && currentEnergy > 0)
        {
            if (state)
            {
                var objects = FindObjectsOfType<spectralSight>();
                foreach (var gameObj in objects)
                {
                    gameObj.SendMessage("toggleOffSpectralLayer");
                }

                    
            }
            else 
            {
                var objects = FindObjectsOfType<spectralSight>();
                foreach (var gameObj in objects)
                {
                    gameObj.SendMessage("toggleOnSpectralLayer");
                }

            }
            state = !state; // Toggle state
        }

        // Get input from player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize movement to prevent faster diagonal movement
        movement = movement.normalized;

        // Handle energy system
        if (state && currentEnergy > 0)
        {
            currentEnergy -= energyDrainRate * Time.deltaTime;

            // If energy runs out, disable night vision automatically
            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                state = false;
            }
        }

        // Update energy bar UI
        if (energyBar != null)
            energyBar.value = currentEnergy;
    }

    void FixedUpdate()
    {
        // Apply movement using Rigidbody2D
        rb.velocity = movement * moveSpeed;
    }

    // Function to recharge energy to full
    public void RechargeEnergy()
    {
        currentEnergy = maxEnergy;

        if (energyBar != null)
            energyBar.value = currentEnergy;
    }

    // Detect collision with an energy particle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Energy"))
        {
            RechargeEnergy();
            Destroy(collision.gameObject); // Remove the energy particle
        }
    }
}
