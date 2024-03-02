using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class GhostBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] LayerMask layerMask;
    GameObject target = null;
    private SpriteRenderer sprite;
    void Awake()
    {
        if(Player.life == Player.Life.Dead)
        {
            Destroy(this.gameObject);
        }
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        Collider2D []colliders = Physics2D.OverlapCircleAll(transform.position, 100, layerMask);
        Tuple<float, GameObject> val = new Tuple<float, GameObject>(math.INFINITY, null);
        for (int i = 0; i < colliders.Length; i++) 
        {
            float dist = (colliders[i].transform.position - transform.localPosition).magnitude;
            if (dist < val.Item1)
            {
                val = new Tuple<float, GameObject> (dist, colliders[i].gameObject);
            }    
        }
        if (val.Item1 == math.INFINITY)
        {
            Debug.Log("Bullet has not found a target ");
            Destroy(this.gameObject);
            return;
        }
        target = val.Item2;
        sprite.enabled = true;


    }

    private void Update()
    {
        if (Player.life == Player.Life.Dead)
        {
            ClearBullet();
        }
        if (target != null)
        {
            Vector3 playerpos = target.transform.position;
            Vector2 vel;
            vel.x = (transform.localPosition - playerpos).x;
            vel.y = (transform.localPosition - playerpos).y;
            vel = vel.normalized;
            vel.x *= -speed;
            vel.y *= -speed;
            rb.velocity = vel;
            if(rb.velocity.sqrMagnitude == 0)
            {
                Destroy(rb.gameObject);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("TakeDamage", damage);
            Destroy(this.gameObject);
        }
    }

    public void ClearBullet()
    {
        Destroy(this.gameObject);
    }
}
