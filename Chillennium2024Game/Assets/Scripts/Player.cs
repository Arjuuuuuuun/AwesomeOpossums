using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // health stuff
    [SerializeField] private int max_health;
     public static int health;
    [SerializeField] private int max_dead_health;
    public static int dead_health;

    // movement stuff
    [SerializeField] private float living_movement_speed;
    [SerializeField] private float dead_movement_speed;
    private Rigidbody2D player_body;
    private Transform player_transform;
    private float x;
    private float y;

    // mode switching
    public enum Life { Alive, Dead };
    private int NumTimesDead = 0;
    public static Life life;
    [SerializeField] private GameObject corpse;

    // rendering
    private new SpriteRenderer renderer;
    [SerializeField] private Sprite alive_sprite;
    [SerializeField] private Sprite dead_sprite;
    private Animator anime;

    void Awake() { 
    
        health = max_health;
        life = Life.Alive;
        // movement stuff
        player_body = GetComponent<Rigidbody2D>();
        player_transform = GetComponent<Transform>();
        anime = GetComponent<Animator>();   
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = alive_sprite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // movement stuff
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 && y != 0)
        {
            dead_movement_speed *= .7071f;
            living_movement_speed *= .7071f;
        }

        player_body.velocity = new Vector2(
            (life == Life.Alive ? living_movement_speed : dead_movement_speed) * x, 
            (life == Life.Alive ? living_movement_speed : dead_movement_speed) * y);

        if (x != 0 && y != 0)
        {
            living_movement_speed /= .7071f;
            dead_movement_speed /= .7071f;
        }
    }

    void TakeDamage(int damage)
    {
        if (life == Life.Alive)
        {
            health -= damage;

            if (health < 0)
            {
                StartCoroutine("Dead");
            }
        }
        else
        {
            dead_health -= damage;
            if (dead_health < 0)
            {
                StartCoroutine("RealDead");
            }
        }
    }

    IEnumerator Dead()
    {
        GameObject.Find("Main Camera").SendMessage("GreyOn");
        GameObject c = Instantiate(corpse, player_transform.position, Quaternion.identity);
        dead_health = max_dead_health;
        life = Life.Dead;
        renderer.sprite = dead_sprite;

        yield return new WaitForSeconds(NumTimesDead * 3 + 5);
        transform.position = c.transform.position;
        Destroy(c);
        ++NumTimesDead;
        health = max_health;
        life = Life.Alive;
        renderer.sprite = alive_sprite;
        GameObject.Find("Main Camera").SendMessage("GreyOff");
    }

    IEnumerator RealDead()
    {
        Debug.Log("end of game");
        yield return new WaitForSeconds(100);

    }


}
