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
    SpriteRenderer sprite;
    Animator animator;
    bool running;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("DogBool", false);
        rb = GetComponent<Rigidbody2D>();
        running = false;
    }
    private void Start()
    {
        animator.SetBool("DogBool", false);
        rb.velocity = new Vector3(speed, 0, 0);
        StartCoroutine(Ataque());
    }
    private void TakeDamage(int damage)
    {
        StartCoroutine(flash());
        health -= damage;
        if(health <= 0) {
            

            StopAllCoroutines();
            ++HeadManager.instance.kill_counter;
            Destroy(gameObject);

        }
        StartCoroutine(DamageAnime());
    }
       
    IEnumerator Ataque()
    {
        while (true)
        {
            running = true;
            animator.SetBool("DogBool", true);

            rb.velocity = new Vector3(0,0,0);
            yield return new WaitForSeconds(.5f);
            Instantiate(projectile, gameObject.transform);
            yield return new WaitForSeconds(.5f);
            running = false;
            animator.SetBool("DogBool", false);

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
        animator.SetBool("DogBool", false);

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

        StartCoroutine(Ataque());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Son")
        {
            collision.SendMessage("takeDamage", 1);
            ++HeadManager.instance.kill_counter;
            Destroy(this.gameObject);
        }
    }

    IEnumerator flash()
    {
        sprite.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1, 1, 1);
    }

}
