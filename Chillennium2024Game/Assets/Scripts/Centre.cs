using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centre : MonoBehaviour
{

    public void TakeDamage(int damage)
    {
       GameObject.Find("Player").SendMessage("TakeDamage", damage);
    }
}
