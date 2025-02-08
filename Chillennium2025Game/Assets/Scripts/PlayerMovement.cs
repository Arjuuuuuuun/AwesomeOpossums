using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxEnergy = 100f;
    public bool spectralOn = false; // False = normal, True = night vision
    public float energyDrainRate = 5f; // Energy drains per second when in night vision mode
    public Slider energyBar; // Assign in the Inspector
    public float cooldownTime;


    private Rigidbody2D rb;
    private Vector2 movement;
    private float currentEnergy;
    private PostProcessVolume ppVolume;
    private LensDistortion ppLens;
    private bool canSwap;
    private SpriteRenderer renderer;
    private Transform trans;

    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;
    [SerializeField] GameObject door3;
    [SerializeField] GameObject door4;

    [SerializeField] GameObject key1;
    [SerializeField] GameObject key2;
    [SerializeField] GameObject key3;
    [SerializeField] GameObject key4;

    [SerializeField] Sprite sideCat;
    [SerializeField] Sprite frontCat;
    [SerializeField] Sprite backCat;


    void Start()
    {
        canSwap = true;
        spectralOn = false;
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        currentEnergy = maxEnergy;

        if (energyBar != null)
            energyBar.maxValue = maxEnergy;
    }

    void Update()
    {
        // Toggle night vision mode with Spacebar (only if energy > 0)
        if (canSwap && Input.GetKeyDown(KeyCode.Space) && currentEnergy > 0)
        {
            if (!spectralOn)
            {
                var objects = FindObjectsOfType<spectralSight>(); 
                foreach(var gameObj in objects){
                    gameObj.SendMessage("toggleOnSpectralLayer", SendMessageOptions.DontRequireReceiver);
                }

                    
            }
            else 
            {
                var objects = FindObjectsOfType<spectralSight>();
                foreach (var gameObj in objects)
                {
                    gameObj.SendMessage("toggleOffSpectralLayer", SendMessageOptions.DontRequireReceiver);
                }

            }
            spectralOn = !spectralOn; // Toggle spectralOn
            canSwap = false;
            StartCoroutine(timer());
        }

        // Get input from player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0)
        {
            renderer.sprite = sideCat;
            trans.localScale = new Vector3(1f, 1f, 1f); // Face right
        }
        else if (movement.x < 0)
        {
            renderer.sprite = sideCat;
            trans.localScale = new Vector3(-1f, 1f, 1f); // Flip horizontally to face left
        }
        else if (movement.y > 0)
        {
            renderer.sprite = backCat;
        }
        else
        {
            renderer.sprite = frontCat;
        }


        // Normalize movement to prevent faster diagonal movement
        movement = movement.normalized;

        // Handle energy system
        if (spectralOn && currentEnergy > 0 && movement.normalized.sqrMagnitude != 0)
        {
            currentEnergy -= energyDrainRate * Time.deltaTime;

            // If energy runs out, disable night vision automatically
            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                spectralOn = false;
                var objects = FindObjectsOfType<spectralSight>();
                foreach (var gameObj in objects)
                {
                    gameObj.SendMessage("toggleOffSpectralLayer", SendMessageOptions.DontRequireReceiver);
                }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Energy"))
        {
            RechargeEnergy();
            Destroy(collision.gameObject); // Remove the energy particle
        }
        if (collision.gameObject == key1)
        {
            Destroy(collision.gameObject );
            Destroy(door1.gameObject);
        }
        if (collision.gameObject == key2)
        {
            Destroy(collision.gameObject );
            Destroy(door2);
        }
        if(collision.gameObject == key3)
        {
            Destroy(collision.gameObject );
            Destroy(door3);
        }
        if(collision.gameObject == key4)
        {
            Destroy(collision.gameObject);
            Destroy(door4);
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(cooldownTime);
        canSwap = true;
    }

}
