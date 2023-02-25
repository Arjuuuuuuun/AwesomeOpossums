using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int enemyBaseHealth;
    void TakeDamage(int val)
    {
        enemyBaseHealth -= val;
        if(enemyBaseHealth <= 0)
        {
            GameObject.Find("GameManager").SendMessage("endGame");
        }
    }
}
