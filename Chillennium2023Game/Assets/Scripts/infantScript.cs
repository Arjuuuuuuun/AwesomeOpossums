using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infantScript : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] float knockBack;
    [SerializeField] float KBT;
    [SerializeField] float WT;
    Rigidbody2D rb;
    [SerializeField] LayerMask CamelMask; 
    [SerializeField] LayerMask BaseMask;
    public GameObject projectile;
    bool running;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        running = false;
    }
    private void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health < 0) StopAllCoroutines();
        Destroy(gameObject);
        StartCoroutine(DamageAnime());
    }

    IEnumerator Ataque()
    {
        while (true)
        {
            running = true;
            rb.velocity = new Vector3(0,0,0);
            Instantiate(projectile, gameObject.transform);
            //add animation here
            yield return new WaitForSeconds(1);
            running = false;
            rb.velocity = new Vector3(speed, 0,0);
            yield return new WaitForSeconds(2);
        }
    }

    private void Update()
    {
        if (!running)
        {
            this.rb.velocity = new Vector3(speed, 0, 0);
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
        running = false;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(DamageAnime());
        collision.gameObject.SendMessage("TakeDamage", damage);
        if (health <= 0)
        {
            StopCoroutine(DamageAnime());
            Destroy(this.gameObject);
        }
    }

}
