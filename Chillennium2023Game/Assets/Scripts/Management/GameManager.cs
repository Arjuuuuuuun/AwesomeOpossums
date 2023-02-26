using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public bool gameActive;
    static public int health;
    public Text healthText;
    private int sonHealth;
    static public bool canGainMoney;
    [SerializeField] private AudioClip fire;
    [SerializeField] private AudioClip money;
    [SerializeField] private AudioClip buy;


    private void Awake()
    {
        health = 40;
        if (HeadManager.instance.level_counter == 2) { health += 15; }
        sonHealth = 5;
        gameActive = true;
        canGainMoney = true;
        StartCoroutine(GameClock());
    }

    private void Update()
    {
        Debug.Log(HeadManager.instance.kill_counter);
        //Updating health slider
        healthText.text = health.ToString() + "/200 " + sonHealth.ToString() + "/5";

        if (Input.GetKeyDown("2"))
        {
            if (HeadManager.instance.is_rat_active)
            {
                buyRat();
                AudioSource.PlayClipAtPoint(buy, GetComponent<Transform>().position);
            }
        }
        else if (Input.GetKeyDown("1"))
        {
            if (HeadManager.instance.is_fox_active)
            {
                buyFox();
                AudioSource.PlayClipAtPoint(buy, GetComponent<Transform>().position);
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            if (HeadManager.instance.is_camel_active)
            {
                buyCamel();
                AudioSource.PlayClipAtPoint(buy, GetComponent<Transform>().position);
            }
        }
        else if (Input.GetKeyDown("f"))
        {
            if (HeadManager.instance.is_powerup_active)
            {
                buyBeam();
                AudioSource.PlayClipAtPoint(fire, GetComponent<Transform>().position);
            }
        }
        else if (Input.GetKeyDown("r"))
        {
            if (HeadManager.instance.is_powerup_active)
            {
                buyMoney();
                AudioSource.PlayClipAtPoint(money, GetComponent<Transform>().position);
            }
        }
    }

    IEnumerator GameClock()
    {
        yield return new WaitForSeconds(2);
        while (gameActive)
        {
            yield return new WaitForSeconds(1);

            if (canGainMoney && health < 195 && HeadManager.instance.tutorial_counter >= 4)
            {
                health += 3;
            }
        }
    }

    void endGame()
    {
        StopAllCoroutines();
        Debug.Log("enemy base deafeated");
        SceneManager.LoadScene(3);

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

    bool buyPowerup()
    {
        if (2 > sonHealth)
        {
            return false;
        }
        GameObject.Find("Son").SendMessage("remoteCallFunnyDamage");
        --sonHealth;
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
        if (buyMinion(40))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnCamel");
        }
    }

    void buyBeam()
    {
        if (buyPowerup())
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnBeam");
        }
    }

    void buyMoney()
    {
        if (buyPowerup())
        {
            health += 55;
        }
    }

    void buyExplode()
    {
        if (buyMinion(10))
        {
            GameObject.Find("PlayerSpawner").BroadcastMessage("Boom", SendMessageOptions.DontRequireReceiver);
            //do things!!!
        }
    }
}
