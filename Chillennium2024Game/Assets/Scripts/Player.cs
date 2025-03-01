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
    private bool iFrame = false;

    // mode switching
    public enum Life { Alive, Dead };
    private int NumTimesDead = 0;
    public static Life life;

    public enum TombstoneType
    {
        radial,
        bullet,
        follow
    }

    public static TombstoneType tombstone;

    // rendering
    private new SpriteRenderer renderer;
    [SerializeField] private Sprite alive_sprite;
    private Animator anime;

    //audio
    private bool tombstoneNear;
    [SerializeField] private AudioClip invalid_build;
    [SerializeField] private AudioClip valid_build;
    [SerializeField] private AudioClip hurt;


    void Awake()
    {

        health = max_health;
        life = Life.Alive;
        // movement stuff
        player_body = GetComponent<Rigidbody2D>();
        player_transform = GetComponent<Transform>();
        anime = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = alive_sprite;
        anime.SetInteger("direction", 0);
        tombstone = TombstoneType.bullet;
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

        if (x > 0)
        {
            anime.SetInteger("direction", 3);
            player_transform.localScale = new Vector3(1, 1, 1);

        }
        else if (x < 0)
        {

            anime.SetInteger("direction", 3);
            player_transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (y > 0) // up, 1
        {
            anime.SetInteger("direction", 1);

        }
        else if (y < 0) // down, 2
        {
            anime.SetInteger("direction", 2);

        }
        else if (x == 0 && y == 0)
        {
            anime.SetInteger("direction", 0);
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
        if (!iFrame)
        {


            AudioSource.PlayClipAtPoint(hurt, new Vector3(0, 0, 0));
            StartCoroutine(IFrame());
            if (life == Life.Alive)
            {
                if (damage == 2)
                {
                    damage = 1;

                }
                else
                    GameObject.Find("Main Camera").SendMessage("Damage");

                health -= damage;

                if (health < 0)
                {
                    if (HeadManager.instance.level_counter == 1)
                    {
                        StartCoroutine("RealDead");
                    }
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
    }
    IEnumerator IFrame()
    {
        iFrame = true;
        yield return new WaitForSeconds(0.2f);
        iFrame = false;
    }
    IEnumerator Dead()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("GhostBullet");
        foreach (GameObject bullet in bullets)
        {
            GameObject.Destroy(bullet);
        }

        yield return new WaitForSeconds(0.5f);
        GameObject.Find("GhostManager").SendMessage("GhostMode");
        dead_health = max_dead_health;
        life = Life.Dead;
        float waitTime;

        switch (NumTimesDead)
        {
            case 0:
                waitTime = 5f;
                break;
            case 1:
                waitTime = 9f;
                break;
            default:
                waitTime = NumTimesDead * 7f;
                break;
        }


        // Find all objects with the tag "health" and send a message
        GameObject[] healthObjects = GameObject.FindGameObjectsWithTag("health");
        foreach (GameObject healthObject in healthObjects)
        {
            healthObject.SendMessage("Death", waitTime);
        }
        yield return new WaitForSeconds(waitTime);

        ++NumTimesDead;
        health = max_health;
        life = Life.Alive;

        renderer.sprite = alive_sprite;

    }

    IEnumerator RealDead()
    {
        GameObject.Find("Spawner").SendMessage("StopCos");
        GameObject.Find("Game Manager").SendMessage("EndGame");
        yield return new WaitForSeconds(100);

    }

    //JANK AUDIO FIX
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tombstone")
        {
            tombstoneNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tombstone")
        {
            tombstoneNear = false;
        }
    }
    private void Reset()
    {
        health = max_health;
        NumTimesDead = 0;
    }

    private void Update()
    {
        if (!tombstoneNear && Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(invalid_build, new Vector3(0, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (tombstone == TombstoneType.radial)
            {
                AudioSource.PlayClipAtPoint(invalid_build, new Vector3(0, 0, 0));
            }
            else
            {
                AudioSource.PlayClipAtPoint(valid_build, new Vector3(0, 0, 0));
            }
            tombstone = TombstoneType.radial;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (tombstone == TombstoneType.bullet)
            {
                AudioSource.PlayClipAtPoint(invalid_build, new Vector3(0, 0, 0));
            }
            else
            {
                AudioSource.PlayClipAtPoint(valid_build, new Vector3(0, 0, 0));
            }
            tombstone = TombstoneType.bullet;
        }
    }

}
