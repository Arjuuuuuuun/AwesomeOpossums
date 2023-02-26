using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] float knockBack;
    [SerializeField] float KBT;
    [SerializeField] float WT;
    [SerializeField] LayerMask mask;
    SpriteRenderer sprite;
    Animator anime;

    Rigidbody2D rb;

    [SerializeField] bool isFox = false;
    bool running;
    bool exploding;
    private void Awake()
    {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        running = exploding = false;
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }
    private void TakeDamage(int damage)
    {
        StartCoroutine(flash());
        health -= damage;
        if (health <= 0)
        {
            StopAllCoroutines();
            Destroy(this.gameObject);
        }
        else
        {
            StartCoroutine(DamageAnime());
        }
    }
    public void Boom()
    {
        if (isFox)
        {
            anime.SetBool("IstanBool", true);
            Debug.Log("one day your car goes boom");
            StartCoroutine(Bom());
        }
    }
    IEnumerator Bom()
    {
        rb.velocity = Vector3.zero;
        speed = 0;
        yield return new WaitForSeconds(0.5);
        exploding = true;
        RaycastHit2D[] arr = Physics2D.RaycastAll(
            new Vector2(transform.position.x + 2, transform.position.y),
            Vector2.left, 4,
             mask);
        for (int i = 0; i < arr.Length; ++i)
        {
            arr[i].collider.gameObject.SendMessage("TakeDamage", 8);
        }
        Destroy(this.gameObject);
    }
    IEnumerator DamageAnime()
    {
        running = true;
        if (this.gameObject != null)
        {
            rb.velocity = new Vector3(knockBack * -speed, 0, 0);
        }
        yield return new WaitForSeconds(KBT);
        if (this.gameObject != null)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        yield return new WaitForSeconds(WT);
        if (this.gameObject != null)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        running =false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", damage);
        
    }
    private void Update()
    {
        if (!running)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    IEnumerator flash()
    {
        sprite.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.3f);
        sprite.color = new Color(1, 1, 1);
    }


}
