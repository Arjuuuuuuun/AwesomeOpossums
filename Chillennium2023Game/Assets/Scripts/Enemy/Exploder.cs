using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] float knockBack;
    [SerializeField] float KBT;
    [SerializeField] float WT;
    bool exploding;
    [SerializeField] LayerMask mask;
    Rigidbody2D rb;
    BoxCollider2D bx;
    Transform trans;

    private void Awake()
    {
        exploding = false;
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        bx = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
    private void TakeDamage(int damage)
    {
        StartCoroutine(DamageAnime());
        health -= damage;
        if(health <= 0)
        {
            StopAllCoroutines();
            Destroy(this.gameObject);
        }
    }

    IEnumerator DamageAnime()
    {
        if (this.gameObject != null)
        {
            rb.velocity = new Vector3(knockBack * 1, 0, 0);
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
    }

    IEnumerator Explode()
    {
        rb.velocity = Vector3.zero;
        speed = 0;
        yield return new WaitForSeconds(2);
        exploding = true;
        RaycastHit2D[] arr = Physics2D.RaycastAll(
            new Vector2(transform.position.x + 2, transform.position.y),
            Vector2.left, 4,
             mask);
        for(int i = 0; i < arr.Length; ++i)
        {
           arr[i].collider.gameObject.SendMessage("TakeDamage",damage);
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
        if (!exploding)
        {
            StartCoroutine(Explode());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!exploding)
        {
            StartCoroutine(Explode());
        }
    }

}
