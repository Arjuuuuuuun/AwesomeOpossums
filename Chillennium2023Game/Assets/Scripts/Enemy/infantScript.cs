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
    [SerializeField] GameObject projectile;
    Rigidbody2D rb;
    bool running;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        running = false;
    }
    private void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
        StartCoroutine(Ataque());
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0) {
            GameObject.Find("GameManager").SendMessage("gainHealth", 30);
            
            //for tutroil purposes 
            if(HeadManager.instance.tutorial_counter == 2) {  ++HeadManager.instance.tutorial_counter;}

            StopAllCoroutines();
            Destroy(gameObject);

        }
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
        StopCoroutine(Ataque());
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
        StartCoroutine(DamageAnime());
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 4 * damage);
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
