using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int direction;
    [SerializeField] private float speed;
    float x, y;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    [SerializeField] private int health;
    [SerializeField] AudioClip enemyDeathSound;

    private Animator anime;
    private SpriteRenderer sr;
    private bool cooldown;

    void Start()
    {
        cooldown = false;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        anime.SetInteger("direction", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.life == Player.Life.Alive && ! cooldown)
        {
            anime.enabled = true;
            // movement stuff
            switch (direction)
            {
                case 1:
                    x = -speed;
                    y = 0;
                    anime.SetInteger("direction", 3);
                    transform.localScale = new Vector3(-1, 1, 1);
                    break;
                case 2:
                    x = speed;
                    y = 0;
                    anime.SetInteger("direction", 3);
                    transform.localScale = new Vector3(1, 1, 1);

                    break;
                case 3:
                    x = 0;
                    y = speed;
                    anime.SetInteger("direction", 1);

                    break;
                case 4:
                    x = 0;
                    y = -speed;
                    anime.SetInteger("direction", 2);

                    break;
            }

            rb.velocity = new Vector2(x, y);
        }
        else
        {
            anime.enabled = false;
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Center"))
        {
            collision.gameObject.SendMessage("TakeDamage", 1);
            GameObject.Destroy(this.gameObject);
        }
    }

    void Rotate(int direction)
    {
        this.direction = direction;
    }

    void TakeDamage(int damage)
    {
        StartCoroutine("FlashRed");
        health -= damage;
        if (health < 0)
        {
            AudioSource.PlayClipAtPoint(enemyDeathSound, Vector3.zero);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Freeze(int freeze_time)
    {
        cooldown = true;
        yield return new WaitForSeconds(freeze_time);
        cooldown = false;
    }

    IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        sr.color = Color.white;
    }

   

}
