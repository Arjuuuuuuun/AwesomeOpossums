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
    [SerializeField] int ghostHealth;
    GameObject target = null;
    private SpriteRenderer sprite;
    bool isTargeting = true;
    [SerializeField] bool targetingFurthest;
    [SerializeField] AudioClip smallTowerShoot;


    void Awake()
    {
        if (!Spawner.in_level)
        {
            Destroy(this.gameObject);
        }
   
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        Collider2D []colliders = Physics2D.OverlapCircleAll(transform.position, 200, layerMask);
        Tuple<float, GameObject> val;
        if (!targetingFurthest) {
            val = new Tuple<float, GameObject>(math.INFINITY, null);
        }
        else
        {
            val = new Tuple<float, GameObject>(-math.INFINITY, null);
        }
        for (int i = 0; i < colliders.Length; i++) 
        {
            float dist = (colliders[i].transform.position - transform.localPosition).magnitude;
            if (dist < val.Item1 && !targetingFurthest)
            {
                val = new Tuple<float, GameObject> (dist, colliders[i].gameObject);
            }    
            else if(dist > val.Item1 && targetingFurthest)
            {
                val = new Tuple<float, GameObject>(dist, colliders[i].gameObject);
            }
        }
        if (val.Item1 == math.INFINITY || val.Item1 == -math.INFINITY)
        {
            Debug.Log("Bullet has not found a target ");
            Destroy(this.gameObject);
            return;
        }
        target = val.Item2;
        sprite.enabled = true;
        AudioSource.PlayClipAtPoint(smallTowerShoot, Vector3.zero);


    }

    private void Update()
    {
        if (target != null && isTargeting)
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("TakeDamage", damage);
            GameObject.Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", 1);
            GameObject.Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Ghost"))
        {
            GameObject.Destroy(collision.gameObject);
            if(--ghostHealth == 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
