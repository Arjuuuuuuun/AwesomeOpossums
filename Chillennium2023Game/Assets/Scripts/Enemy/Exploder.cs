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
    Rigidbody2D rb;
    Transform trans;

    private void Awake()
    {
        exploding = false;
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
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
    }

    IEnumerator Explode()
    {
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(2);
        exploding = true;
        trans.position = new Vector3(trans.position.x,trans.position.y+100,trans.position.z);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Explode());
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (exploding) { collision.gameObject.SendMessage("TakeDamage", damage); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Explode());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (exploding) { collision.gameObject.SendMessage("TakeDamage", damage); }
    }

}
