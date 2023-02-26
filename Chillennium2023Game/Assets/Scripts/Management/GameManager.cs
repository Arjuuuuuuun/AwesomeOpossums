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
    public GameObject screenFlash;
    static public bool canGainMoney;
    [SerializeField] private AudioClip fire;
    [SerializeField] private AudioClip money;
    [SerializeField] private AudioClip buy;
    [SerializeField] private AudioClip denied;


    private void Awake()
    {
        health = 40;
        if (HeadManager.instance.level_counter == 2) { health += 15; }
        sonHealth = 6;
        gameActive = true;
        canGainMoney = true;
        StartCoroutine(GameClock());
        screenFlash.SetActive(false);
    }

    private void Update()
    {
        //Updating health slider
        healthText.text = health.ToString() + "/200 " + sonHealth.ToString() + "/6";

        if (Input.GetKeyDown("2"))
        {
            if (HeadManager.instance.is_rat_active)
            {
                buyRat();
            }
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
            if (HeadManager.instance.is_camel_active)
            {
                buyCamel();
            }
        }
        else if (Input.GetKeyDown("f"))
        {
            if (HeadManager.instance.is_powerup_active)
            {
                buyBeam();
            }
        }
        else if (Input.GetKeyDown("r"))
        {
            if (HeadManager.instance.is_powerup_active)
            {
                buyMoney();
            }
        }
        //else if (Input.GetKeyDown("e"))
        //{
        //    if(HeadManager.instance.is_rat_active)
        //        buyExplode();
        //}
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
        StartCoroutine(flash());
        if (sonHealth <= 0)
        {
            endGame();
        }
    }

    IEnumerator flash()
    {
        screenFlash.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        screenFlash.SetActive(false);
    }
    public void buyRat()
    {
        if (buyMinion(15))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnRat");
            AudioSource.PlayClipAtPoint(buy, GetComponent<Transform>().position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(denied, GetComponent<Transform>().position);
        }
    }

    public void buyFox()
    {
        if (buyMinion(20))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnFox");
            AudioSource.PlayClipAtPoint(buy, GetComponent<Transform>().position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(denied, GetComponent<Transform>().position);
        }
    }

    public void buyCamel()
    {
        if (buyMinion(40))
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnCamel");
            AudioSource.PlayClipAtPoint(buy, GetComponent<Transform>().position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(denied, GetComponent<Transform>().position);
        }
    }

    void buyBeam()
    {
        if (buyPowerup())
        {
            GameObject.Find("PlayerSpawner").SendMessage("SpawnBeam");
            AudioSource.PlayClipAtPoint(fire, GetComponent<Transform>().position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(denied, GetComponent<Transform>().position);
        }
    }

    void buyMoney()
    {
        if (buyPowerup())
        {
            health += 55;
            AudioSource.PlayClipAtPoint(money, GetComponent<Transform>().position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(denied, GetComponent<Transform>().position);
        }
    }

    void buyExplode()
    {

        GameObject.Find("PlayerSpawner").BroadcastMessage("Boom", SendMessageOptions.DontRequireReceiver);
    }
}
