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

    private void Update()
    {
        if(transform.position.x <= -8.5)
        {
            GameObject.Find("Son").SendMessage("takeDamage", 1);
            Destroy(gameObject);
        }
    }
    void TakeDamage(int damage)
    {
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerBase" || collision.gameObject.tag == "Beam")
        {
            Destroy(gameObject);
            return;
        }
        if(collision.gameObject.tag == "Son") { Debug.Log("yeah"); }
        collision.gameObject.SendMessage("TakeDamage", damage);
        if (collision.gameObject.tag == "Camel" && !camelExemption)
        {
            Destroy(gameObject);
        }
    }
}
