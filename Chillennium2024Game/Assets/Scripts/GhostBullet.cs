using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class GhostBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    public void MakeGo(int degree)
    {
        switch (degree)
        {
            case 0:
                rb.velocity = new Vector2(0, speed);
                break;
            case 90:
                rb.velocity = new Vector2(speed, 0);
                break;
            case 180:
                rb.velocity = new Vector2(0, -speed);
                break;
            case 270:
                rb.velocity = new Vector2(-speed, 0);
                break;
        }

    }
}
