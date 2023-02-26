using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] float knockBack;
    [SerializeField] float KBT;
    [SerializeField] float WT;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    bool running;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        running = false;
    }
    private void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
    private void TakeDamage(int damage)
    {
        StartCoroutine(flash());
        health -= damage;
        if (health <= 0)
        {
            StopAllCoroutines();
            ++HeadManager.instance.kill_counter;
            Destroy(this.gameObject);
        }
        else
        {
            StartCoroutine(DamageAnime());
        }
    }

    IEnumerator DamageAnime()
    {
        running = true;
        if (this.gameObject != null)
        {
            rb.velocity = new Vector3(knockBack * -speed, 0, 0);
        }
        yield return new WaitForSeconds(KBT);
        if (this.gameObject != null)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        yield return new WaitForSeconds(WT);
        if (this.gameObject != null)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        running =false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "PlayerBase")
        {
            collision.gameObject.SendMessage("TakeDamage", damage);
        }
    }
    private void Update()
    {
        if (!running)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Son")
        {
            collision.SendMessage("takeDamage",1);
            ++HeadManager.instance.kill_counter;
            Destroy(gameObject);
        }
    }

    IEnumerator flash()
    {
        sprite.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1, 1, 1);
    }


}
