using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxEnergy = 25f;
    public bool spectralOn = false; // False = normal, True = night vision
    public float energyDrainRate = 2f; // Energy drains per second when in night vision mode
    public Slider energyBar; // Assign in the Inspector
    public float cooldownTime;
    public bool canSwap;

    [SerializeField] float spectralSightAnimationTime;
    [SerializeField] float spectralSightDelay;
    [SerializeField] Sprite Key1Image;
    [SerializeField] Sprite Key2Image;
    [SerializeField] Sprite Key3Image;
    [SerializeField] Sprite Key4Image;

    [SerializeField] Sprite Door1Image;
    [SerializeField] Sprite Door2Image;
    [SerializeField] Sprite Door3Image;
    [SerializeField] Sprite Door4Image;
    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;
    [SerializeField] GameObject door3;
    [SerializeField] GameObject door4;

    [SerializeField] GameObject key1;
    [SerializeField] GameObject key2;
    [SerializeField] GameObject key3;
    [SerializeField] GameObject key4;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float currentEnergy;
    private SpriteRenderer renderer;
    private Transform trans;

    Light2D lighting;



    [SerializeField] Sprite sideCat;
    [SerializeField] Sprite frontCat;
    [SerializeField] Sprite backCat;

    [SerializeField] GameObject jumpScare;
    void Start()
    {
        canSwap = true;
        spectralOn = false;
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        lighting = GetComponentInChildren<Light2D>();
        currentEnergy = maxEnergy;

        if (energyBar != null)
            energyBar.maxValue = maxEnergy;

        // Assign sprites to keys
        key1.GetComponent<SpriteRenderer>().sprite = Key1Image;
        key2.GetComponent<SpriteRenderer>().sprite = Key2Image;
        key3.GetComponent<SpriteRenderer>().sprite = Key3Image;
        key4.GetComponent<SpriteRenderer>().sprite = Key4Image;

        // Assign sprites to doors
        door1.GetComponent<SpriteRenderer>().sprite = Door1Image;
        door2.GetComponent<SpriteRenderer>().sprite = Door2Image;
        door3.GetComponent<SpriteRenderer>().sprite = Door3Image;
        door4.GetComponent<SpriteRenderer>().sprite = Door4Image;
    }

    void Update()
    {
        

        // Get input from player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize movement to prevent faster diagonal movement
        movement = movement.normalized;
        if(movement.sqrMagnitude > 0 && spectralOn)
        {
            canSwap = false;
            spectralOn = false;
            var objects = FindObjectsOfType<spectralSight>();
            foreach (var gameObj in objects)
            {
                gameObj.SendMessage("toggleOffSpectralLayer", SendMessageOptions.DontRequireReceiver);
            }
            StopAllCoroutines();
            StartCoroutine(timer());
            StartCoroutine(fromSpectralSight());

        }

        // Toggle night vision mode with Spacebar (only if energy > 0)
        else if (canSwap && Input.GetKeyDown(KeyCode.Space) && currentEnergy > 0 && movement.sqrMagnitude <= 0)
        {
            if (!spectralOn)
            {


                spectralOn = true; // Toggle spectralOn
                StartCoroutine(toSpectralSight());
                canSwap = true;


            }
            else
            {

                var objects = FindObjectsOfType<spectralSight>();
                foreach (var gameObj in objects)
                {
                    gameObj.SendMessage("toggleOffSpectralLayer", SendMessageOptions.DontRequireReceiver);
                }

                spectralOn = false; // Toggle spectralOn
                StopAllCoroutines();
                StartCoroutine(fromSpectralSight());
                canSwap = false;


            }
            StartCoroutine(timer());

        }
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



        // Handle energy system
        if (spectralOn && currentEnergy > 0 )
        {
            currentEnergy -= energyDrainRate * Time.deltaTime;

            // If energy runs out, disable night vision
            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                spectralOn = false;
                var objects = FindObjectsOfType<spectralSight>();
                foreach (var gameObj in objects)
                {
                    gameObj.SendMessage("toggleOffSpectralLayer", SendMessageOptions.DontRequireReceiver);
                }
                canSwap = false;
                StopAllCoroutines();
                StartCoroutine (timer());
                StartCoroutine(fromSpectralSight());
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
            var objects = FindObjectsOfType<spectralSight>();
            foreach (var gameObj in objects)
            {
                gameObj.SendMessage("toggleOffSpectralLayer", SendMessageOptions.DontRequireReceiver);
            }

            spectralOn = false; // Toggle spectralOn
            canSwap = false;
            StopCoroutine(toSpectralSight());
            lighting.pointLightInnerRadius = 3f;
            lighting.pointLightOuterRadius = 5f;
            lighting.color = Color.white;
            Instantiate(jumpScare);
            Destroy(collision.gameObject);
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
            door1.SendMessage("InitiateDestructionSequence");
        }
        if (collision.gameObject == key2)
        {

            door2.SendMessage("InitiateDestructionSequence");
        }
        if(collision.gameObject == key3)
        {

            door3.SendMessage("InitiateDestructionSequence");
        }
        if(collision.gameObject == key4)
        {

            door4.SendMessage("InitiateDestructionSequence");
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(cooldownTime);
        canSwap = true;
    }

    IEnumerator toSpectralSight()
    {
        yield return new WaitForSeconds(spectralSightDelay);
        lighting.pointLightInnerRadius = 3f;
        lighting.pointLightOuterRadius = 5f;
        lighting.color = Color.white;
        float totalTime = 0.0f;
        while(totalTime < spectralSightAnimationTime)
        {
            float slope = ((17 - 3) / (spectralSightAnimationTime));
            lighting.pointLightInnerRadius = (slope * totalTime + 3f);
            lighting.pointLightOuterRadius = (slope * totalTime + 5f);

            float bSlope = ((30 - 255) / (spectralSightAnimationTime));
            float aSlope = ((255 - 255) / (spectralSightAnimationTime));

            lighting.color = new Color(1,1, (bSlope * totalTime + 255) / 255, (aSlope * totalTime + 255) / 255); 

            yield return new WaitForSeconds(0.01f);
            totalTime += 0.01f;
        }
        var objects = FindObjectsOfType<spectralSight>();
        foreach (var gameObj in objects)
        {
            gameObj.SendMessage("toggleOnSpectralLayer", SendMessageOptions.DontRequireReceiver);
        }

    }

    IEnumerator fromSpectralSight()
    {
        float initInnerRadius = lighting.pointLightInnerRadius;
        float initOuterRaduis = lighting.pointLightOuterRadius;
        float initR = lighting.color.r;
        float initB = lighting.color.b; 
        float initA = lighting.color.a;
        Debug.Log(lighting.color);
        float totalTime = 0.0f;
        while (totalTime < spectralSightAnimationTime)
        {
            float slope = -((initInnerRadius - 3) / (spectralSightAnimationTime));
            lighting.pointLightInnerRadius = (slope * totalTime + initInnerRadius);
            lighting.pointLightOuterRadius = (slope * totalTime + initOuterRaduis);

            float bSlope = -((initB * 255 - 255) / (spectralSightAnimationTime));
            float aSlope = -((initA * 255 - 255) / (spectralSightAnimationTime));


            lighting.color = new Color(1, 1, (bSlope * totalTime + initB * 255) / 255, (aSlope * totalTime + initA * 255) / 255);

            yield return new WaitForSeconds(0.01f);
            totalTime += 0.01f;
        }

    }

}
