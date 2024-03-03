using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        if (velocity.x < 0)
        {
            transform.localScale =new Vector3(-1, 1, 1);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", 1);
            GameObject.Destroy(gameObject);
        }
    }
}
