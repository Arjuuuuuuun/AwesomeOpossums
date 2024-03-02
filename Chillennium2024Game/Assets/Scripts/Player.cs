using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movement_speed;
    private Rigidbody2D player_body;
    private Transform player_transform;
    private float x;
    private float y;

    
    void Awake()
    {
        player_body = GetComponent<Rigidbody2D>();
        player_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 && y != 0)
        {
            movement_speed *= .7071f;
        }

        player_body.velocity = new Vector2(movement_speed * x, movement_speed * y);

        if (x != 0 && y != 0)
        {
            movement_speed /= .7071f;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tombstone") && Input.GetKeyDown(KeyCode.Space))
        {
            collision.gameObject.SendMessage("Activate");
        }
    }
}
