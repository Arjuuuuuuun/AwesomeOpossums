using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int damage;
    [SerializeField] float speed;
    Rigidbody2D rb;
    [SerializeField] bool camelExemption;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(speed, 0,0);  
    }
    void TakeDamage(int damage)
    {
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBase")
        {
            Destroy(gameObject);
            return;
        }
        collision.gameObject.SendMessage("TakeDamage", damage);
        if (collision.gameObject.tag == "Camel" && !camelExemption)
        {
            Destroy(gameObject);
        }
    }
}
