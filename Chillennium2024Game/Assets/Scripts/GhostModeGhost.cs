using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostModeGhost : MonoBehaviour
{
    Rigidbody2D body;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();   
    }


    void init(Vector2 position)
    {
        body.position = position;
    }

    void init2(Vector2 velocity)
    {
        body.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", 1);
            GameObject.Destroy(gameObject);
        }
    }
}
