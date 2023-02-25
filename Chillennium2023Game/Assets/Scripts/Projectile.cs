using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int damage;
    [SerializeField] float speed;
    Rigidbody2D rb; 
    [SerializeField] LayerMask CamelMask;
    [SerializeField] LayerMask BaseMask;
    void Start()
    {
        rb.velocity = new Vector3(speed, 0,0);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", damage);
        if (collision.gameObject.layer.Equals(CamelMask) || collision.gameObject.layer.Equals(BaseMask))
        {
            Destroy(gameObject);
        }
    }
}
