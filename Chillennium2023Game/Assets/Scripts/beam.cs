using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beam : MonoBehaviour
{
    Rigidbody2D rb;
    public AudioClip damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void TakeDamage(int val)
    {
        return;
    }
    void Update()
    {
        rb.velocity = 5 * Vector2.right;
        if (transform.position.x >= 11)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(damage, GetComponent<Transform>().position);
        if (collision.tag == "Enemy")
        {
            collision.gameObject.SendMessage("TakeDamage", 8);
        }
        else
        {
            collision.gameObject.SendMessage("TakeDamage", 15, SendMessageOptions.DontRequireReceiver);
        }
    }

}
