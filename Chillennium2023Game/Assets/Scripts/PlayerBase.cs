using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    void TakeDamage(int val)
    {
        GameObject.Find("GameManager").SendMessage("gainHealth", -val);
    }

}