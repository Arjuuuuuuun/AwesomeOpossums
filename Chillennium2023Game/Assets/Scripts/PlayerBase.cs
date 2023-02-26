using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    Transform ts;
    [SerializeField] float speed;
    static public int level;

    private void Awake()
    {
        ts = GetComponent<Transform>();
        level = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            if (level < 4)
            {
                ++level;
            }
        }

        else if (Input.GetKeyDown("s"))
        {
            if (level > 1)
            {
                --level;
            }
        }
        
        switch (level)
        {
            case (1):
                ts.position = new Vector3(ts.position.x, -3.25f, ts.position.z);
                break;

            case (2):
                ts.position = new Vector3(ts.position.x, -1.5f, ts.position.z);
                break;

            case (3):
                ts.position = new Vector3(ts.position.x, 0.25f, ts.position.z);
                break;

            case (4):
                ts.position = new Vector3(ts.position.x, 2f, ts.position.z);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

}



