using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float xVelocity;
    [SerializeField] float yVelocity;
    [SerializeField] float patrolDistance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            rb.velocity = new Vector2(xVelocity, yVelocity);
            yield return new WaitForSeconds(patrolDistance / MathF.Sqrt(xVelocity * xVelocity + yVelocity * yVelocity));
            rb.velocity = new Vector2(-xVelocity,   -yVelocity);
            yield return new WaitForSeconds(patrolDistance / MathF.Sqrt(xVelocity * xVelocity + yVelocity * yVelocity));
        }
    }
}
