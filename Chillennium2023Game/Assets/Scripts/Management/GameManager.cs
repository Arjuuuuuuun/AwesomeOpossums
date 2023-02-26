using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public bool gameActive;
    static public int health;
    public Text healthText;
    public Slider healthbar;
    private int sonHealth;


    private void Awake()
    {
        health = 40;
        sonHealth = 5;
        gameActive = true;
        StartCoroutine(GameClock());
    }

    private void Update()
    {
        //Updating health slider
        healthText.text = health.ToString() + "/200 " + sonHealth.ToString() + "/5";

        if (Input.GetKeyDown("2"))
        {
            buyRat();
        }
        else if (Input.GetKeyDown("1"))
        {
            if (HeadManager.instance.is_fox_active)
            {
                buyFox();
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            buyCamel();
        }
        else if (Input.GetKeyDown("q"))
        {
            buyBeam();
        }
    }

    IEnumerator GameClock()
    {
        yield return new WaitForSeconds(2);
        while (gameActive)
        {
            yield return new WaitForSeconds(1);

            if (health < 195 && HeadManager.instance.tutorial_counter >= 4)
            {
                health += 3;
            }
        }
    }

    void endGame()
    {
        StopAllCoroutines();
        Debug.Log("enemy base deafeated");
        //end the game
    }

    bool buyMinion(int cost)
    {
        if (cost > health)
        {
            return false;
        }
        health -= cost;
        return true;
    }

    void TakeSonDamage(int val)
    {
        sonHealth -= val;
        if (sonHealth <= 0)
        {
            endGame();
        }
    }
    public void buyRat()
    {
        if (buyMinion(30))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnRat");
        }
    }

    public void buyFox()
    {
        if (buyMinion(20))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnFox");
        }
    }

    public void buyCamel()
    {
        if (buyMinion(55))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnCamel");
        }
    }

    void buyBeam()
    {
        if (buyMinion(20))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnBeam");
        }
    }

    void buyExplode()
    {
        if (buyMinion(10))
        {
           
            //do things!!!
        }
    }
}
