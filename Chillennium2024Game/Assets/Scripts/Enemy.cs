using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int direction;
    [SerializeField] private int speed;
    float x, y;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    [SerializeField] private int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.life == Player.Life.Alive)
        {
            // movement stuff
            switch (direction)
            {
                case 1:
                    x = -speed;
                    y = 0;
                    break;
                case 2:
                    x = speed;
                    y = 0;
                    break;
                case 3:
                    x = 0;
                    y = speed;
                    break;
                case 4:
                    x = 0;
                    y = -speed;
                    break;
            }

            rb.velocity = new Vector2(x, y);
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    void Rotate(int direction)
    {
        this.direction = direction;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
