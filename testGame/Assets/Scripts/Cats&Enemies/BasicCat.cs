using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCat : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int health;
    [SerializeField] public int damage;
    public Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = new Vector2(5.0f, 0.0f);
    }


    private void takeDamage(int incDamage)
    {
        health -= incDamage;
        if(health <= 0) { Object.Destroy(gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
