using System.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class SpinnyGhost : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int damagePerSecond;
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
            ClearBullet();
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

    public void ClearBullet()
    {
        Destroy(this.gameObject);
    }
}
