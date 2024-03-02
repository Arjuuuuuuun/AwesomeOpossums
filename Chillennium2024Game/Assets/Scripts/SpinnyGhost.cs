using System.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class SpinnyGhost : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int damagePerSecond;
    private bool canTick = true;
    [SerializeField] float timeOnSide;
    [SerializeField] float deadSpeed;
    [SerializeField] float timeAlive;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FakeFixedUpdate());
        StartCoroutine(Kill());
    }
    private void FixedUpdate()
    {
        if(Player.life == Player.Life.Dead)
        {
            StopAllCoroutines();
            Transform playerTransform = GameObject.Find("Player").transform;
            Vector3 playerpos = playerTransform.position;
            Vector2 vel;
            vel.x = (transform.localPosition - playerpos).x;
            vel.y = (transform.localPosition - playerpos).y;
            vel = vel.normalized;
            vel.x *= -deadSpeed;
            vel.y *= -deadSpeed;
            rb.velocity = vel;
        }
    }
    IEnumerator Kill()
    {
        yield return new WaitForSeconds(timeAlive);
        GameObject.Destroy(this.gameObject);
    }
    IEnumerator FakeFixedUpdate()
    {
        while (true)
        {
            rb.velocity = new Vector2(0, speed);
            yield return new WaitForSeconds(timeOnSide);
            rb.velocity = new Vector2(-speed, 0);
            yield return new WaitForSeconds(timeOnSide);
            rb.velocity = new Vector2(0, -speed);
            yield return new WaitForSeconds(timeOnSide);
            rb.velocity = new Vector2(speed, 0);
            yield return new WaitForSeconds(timeOnSide);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("TakeDamage", damagePerSecond);
        }
    }

    IEnumerator Damage(GameObject obj)
    {
        canTick = false;
        obj.SendMessage("TakeDamage", damagePerSecond);
        yield return new WaitForSeconds(1f);
        canTick = true; 
    }

    public void ClearBullet()
    {
        Destroy(this.gameObject);
    }
}
