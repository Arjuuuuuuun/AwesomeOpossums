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
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamageAnime());
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", damage);
        if (health <= 0)
        {
            StopCoroutine(DamageAnime());
            Destroy(this.gameObject);
        }
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
