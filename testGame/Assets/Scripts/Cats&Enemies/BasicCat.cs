using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCat : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int health;
    [SerializeField] int damage;
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void takeDamage(int incDamage)
    {
        health -= incDamage;
        if(health <= 0) { Object.Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy other = collision.gameObject.GetComponent<Enemy>();
    }
}
