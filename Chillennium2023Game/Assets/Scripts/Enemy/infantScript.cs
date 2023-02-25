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
    Animator animator;
    bool running;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        running = false;
    }
    private void Start()
    {
        animator.SetBool("isWalking", true);
        rb.velocity = new Vector3(speed, 0, 0);
        StartCoroutine(Ataque());
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0) {
            
            //for tutroil purposes 
            if(HeadManager.instance.tutorial_counter == 2) {
                ++HeadManager.instance.tutorial_counter;
                GameObject.Find("Fox(Clone)").SendMessage("TakeDamage", 10000);
                GameObject.Find("GameManager").SendMessage("setHealth", 100);
            }
            //end of tutriol purposes

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
            animator.SetBool("isWalking", false);

            rb.velocity = new Vector3(0,0,0);
            yield return new WaitForSeconds(.5f);
            Instantiate(projectile, gameObject.transform);
            yield return new WaitForSeconds(.5f);
            running = false;
            animator.SetBool("isWalking", true);

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
        animator.SetBool("isWalking", false);

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
        animator.SetBool("isWalking", true);

        StartCoroutine(Ataque());
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 4 * damage);
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
