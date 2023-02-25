using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Son : MonoBehaviour
{

    // Update is called once per frame
    void takeDamage(int val)
    {
        GameObject.Find("GameManager").SendMessage("TakeSonDamage", val);        
    }
}
