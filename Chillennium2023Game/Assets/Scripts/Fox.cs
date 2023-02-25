using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] float knockBack;
    [SerializeField] float KBT;
    Rigidbody2D rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rigidbody.velocity = new Vector3(speed, 0, 0);
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(DamageAnime());
    }

    IEnumerator DamageAnime()
    {
        rigidbody.velocity = new Vector3(-knockBack * speed, 0, 0);
        Debug.Log("called");
        yield return new WaitForSeconds(KBT);

        rigidbody.velocity = new Vector3(0, 0, 0);
        Debug.Log("called");

        yield return new WaitForSeconds(KBT);
        Debug.Log("called");

        rigidbody.velocity = new Vector3(speed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 6);
        if (health <= 0)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 3);
    }

}
