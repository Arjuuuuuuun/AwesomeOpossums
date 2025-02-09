using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingGhostScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float velocity;
    PlayerMovement player;
    Transform trans;
    void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = -(transform.position - player.transform.position).normalized;

        if (player.spectralOn)
        {
            rb.velocity = new Vector2(direction.x * velocity, direction.y * velocity);

            // Flip the object based on movement direction
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z); // Facing right
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z); // Facing left
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

}
