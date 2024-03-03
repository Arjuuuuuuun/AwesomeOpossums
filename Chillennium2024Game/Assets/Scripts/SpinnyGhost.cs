using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class SpinnyGhost : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int enemyDamage;
    private SpriteRenderer sprite;
    [SerializeField] int health;
    void Awake()
    {
        if (!Spawner.in_level)
        {
            Destroy(this.gameObject);
        }


        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        sprite.enabled = true;


    }

    private void Update()
    {

        Vector3 playerpos = GameObject.Find("Player").transform.position;
        Vector2 vel;
        vel.x = (transform.localPosition - playerpos).x;
        vel.y = (transform.localPosition - playerpos).y;
        vel = vel.normalized;
        vel.x *= -speed;
        vel.y *= -speed;
        rb.velocity = vel;
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("TakeDamage", enemyDamage);
            if(--health == 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", 1);
            GameObject.Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ghost"))
        {
            GameObject.Destroy(collision.gameObject);
            if (--health == 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
