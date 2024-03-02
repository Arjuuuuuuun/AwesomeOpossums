using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int direction; // 1,2,3,4 for left right up down respectively

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("Rotate", direction);
    }
}
