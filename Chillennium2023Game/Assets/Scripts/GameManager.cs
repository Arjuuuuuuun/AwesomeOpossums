using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public int health;

   // Update is called once per frame
    void Update()
    {
        
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
