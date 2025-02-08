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
    private Transform trans;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        while (true)
        {
            rb.velocity = new Vector2(xVelocity, yVelocity);
            if (xVelocity > 0)  trans.localScale = new Vector3(1, 1,1);  
            else trans.localScale = new Vector3(-1, 1,1);
            yield return new WaitForSeconds(patrolDistance / MathF.Sqrt(xVelocity * xVelocity + yVelocity * yVelocity));
            rb.velocity = new Vector2(-xVelocity,   -yVelocity);
            if (xVelocity <= 0) trans.localScale = new Vector3(1,1, 1);
            else trans.localScale = new Vector3(-1,1, 1);
            yield return new WaitForSeconds(patrolDistance / MathF.Sqrt(xVelocity * xVelocity + yVelocity * yVelocity));
        }
    }
}
