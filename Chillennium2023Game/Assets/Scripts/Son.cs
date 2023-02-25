using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Son : MonoBehaviour
{

    public static int sonHealth;
    // Update is called once per frame
    void takeDamage(int val)
    {
        sonHealth -= val;
        if(sonHealth <= 0)
        {
            GameObject.Find("GameManager").SendMessage("endGame");
        }
    }
}
