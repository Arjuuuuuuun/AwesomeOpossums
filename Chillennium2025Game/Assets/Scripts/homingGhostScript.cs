using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingGhostScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float velocity;
    PlayerMovement player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = -(transform.position - player.transform.position).normalized;
        if (player.spectralOn)
        {
            
            rb.velocity = new Vector2(direction.x * velocity, direction.y * velocity);
        }
        else {
            rb.velocity = Vector2.zero;
        }
    }
}
