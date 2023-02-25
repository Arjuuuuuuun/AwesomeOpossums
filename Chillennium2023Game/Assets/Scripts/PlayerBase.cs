using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void TakeDamage(int val)
    {
        GameObject.Find("GameManager").SendMessage("gainHealth", -val);
    }

    private void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0, speed);
        }

        else if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, -speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}



