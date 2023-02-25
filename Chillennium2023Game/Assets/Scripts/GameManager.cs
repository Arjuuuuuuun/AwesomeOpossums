using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public bool gameActive;
    static public int health;


    private void Awake()
    {
        health = 100;
        gameActive = true;
        StartCoroutine(GameClock());
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameActive = false;
        }
    }

    IEnumerator GameClock()
    {
        yield return new WaitForSeconds(2);
        while (gameActive)
        {
            yield return new WaitForSeconds(2);
            if (health < 190)
            {
                health += 10;
            }
            else
            {
                health = 200;
            }
        }
    }


    bool buyMinion(int cost)
    {
        if(cost > health)
        {
            return false;
        }
        health -= cost;
        return true;
    }
    void gainHealth(int amount)
    {
        health += amount;
    }

    public void buyRat()
    {
        if (buyMinion(30))
        {
            //SPAWN RAT
            Debug.Log("Rat Spawned");
        }
    }

    public void buySnake()
    {
        if (buyMinion(40))
        {
            //SPAWN SNAKE
            Debug.Log("Snake Spawned");
        }
    }

    public void buyFox()
    {
        if (buyMinion(20))
        {
            //SPAWN FOX
            Debug.Log("Fox Spawned");
        }
    }

    public void buyCamel()
    {
        if (buyMinion(55))
        {
            //SPAWN CAMEL
            Debug.Log("Camel Spawned");
        }
    }
}
