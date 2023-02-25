using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public bool gameActive;
    static public int health;


    private void Awake()
    {
        health = 100;
        StartCoroutine(GameClock());
    }

    IEnumerator GameClock()
    {
        yield return new WaitForSeconds(2);
        while (gameActive)
        {
            yield return new WaitForSeconds(2);
            health += 10;
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
}
