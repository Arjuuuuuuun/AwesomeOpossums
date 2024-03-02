using System.Collections;
using UnityEngine;

public class Tombstone : MonoBehaviour
{

    [SerializeField] protected enum TombstoneState {notActive, Active };
    protected TombstoneState state;
    [SerializeField] protected float tombstoneAwakeTime;
    bool playerNear;
    protected enum TowerType {Radial,Bullet, Follow };

    TowerType type;


    bool radCanSpawnGhost = true;
    [SerializeField] GameObject radGhost;
    [SerializeField] float radGhostInitDelay;
    [SerializeField] float radGhostSpawnRate;

    bool bulCanFire = true;
    [SerializeField] GameObject bulBullet;
    [SerializeField] float bulFireRate;
    [SerializeField] float bulTimeBeforeFirstFire;

    [SerializeField] private GameObject skull;

    private Animator anime;
    [SerializeField] private Sprite flameless_skull;





    void Start()
    {

        anime = skull.GetComponent<Animator>();
        anime.enabled = false;
        skull.GetComponent<SpriteRenderer>().sprite = flameless_skull;

        state = TombstoneState.notActive;

    }

    void Update()
    {

        switch (state) {
            case TombstoneState.notActive:
                anime.enabled = false;
                skull.GetComponent<SpriteRenderer>().sprite = flameless_skull;
                if (playerNear && Input.GetKeyDown(KeyCode.Space))
                {
                   StartCoroutine(ActiveTimer());
                    switch (Player.tombstone)
                    {
                        case(Player.TombstoneType.radial):
                            anime.SetBool("Colour", false); anime.enabled = true;

                            type = TowerType.Radial;
                            break;
                        case(Player.TombstoneType.bullet):
                            anime.SetBool("Colour", true); anime.enabled = true;

                            type = TowerType.Bullet;
                            break;
                        case (Player.TombstoneType.follow):
                            type = TowerType.Follow;
                            break;
                    }
                }
                break;
            case TombstoneState.Active:
                ActivateFire();
                break;   
        }
    }
    IEnumerator CheckPlayerState()
    {
        while (true)
        {
            yield return new WaitUntil(() => Player.life == Player.Life.Alive);

        }
    }
    void ActivateFire()
    {
        switch (type)
        {
            case TowerType.Radial:
                if (radCanSpawnGhost)
                {
                    StartCoroutine(RadSpawnCooldown());
                }
                break;
            case TowerType.Bullet:
                if (bulCanFire)
                {
                    StartCoroutine(BulFire());
                }
                break;
            case TowerType.Follow:
                break;
        }
    }


    IEnumerator BulFire()
    {
        bulCanFire = false;
        yield return new WaitForSeconds(bulFireRate);
        GameObject b = Instantiate(bulBullet, this.transform.position, Quaternion.identity);
        bulCanFire = true;
    }

    IEnumerator RadSpawnCooldown()
    {
        radCanSpawnGhost = false;
        yield return new WaitForSeconds(radGhostInitDelay);
        GameObject b = Instantiate(radGhost, new Vector2(transform.position.x + 1.25f, transform.position.y - 1.25f), Quaternion.identity);
        yield return new WaitForSeconds(radGhostSpawnRate);
        radCanSpawnGhost = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNear = false;
        }
    }

    IEnumerator ActiveTimer()
    {
        state = TombstoneState.Active;
        yield return new WaitForSeconds(tombstoneAwakeTime);
        state = TombstoneState.notActive;
    }


}
