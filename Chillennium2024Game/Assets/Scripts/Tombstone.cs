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

    protected SpriteRenderer spriteRenderer;

    bool radCanSpawnGhost = true;
    [SerializeField] GameObject radGhost;
    [SerializeField] float radGhostInitDelay;
    [SerializeField] float radGhostSpawnRate;

    bool bulCanFire = true;
    [SerializeField] GameObject bulBullet;
    [SerializeField] float bulFireRate;
    [SerializeField] float bulTimeBeforeFirstFire;

    [SerializeField] private GameObject cirlce;

    void Start()
    {
        state = TombstoneState.notActive;
        spriteRenderer = GetComponent<SpriteRenderer>();
        cirlce.GetComponent<SpriteRenderer>().enabled = false;

    }

    void Update()
    {

        switch (state) {
            case TombstoneState.notActive:
                spriteRenderer.color = Color.gray;
                if (playerNear && Input.GetKeyDown(KeyCode.Space))
                {
                   StartCoroutine(ActiveTimer());
                    switch (Player.tombstone)
                    {
                        case(Player.TombstoneType.radial):
                            type = TowerType.Radial;
                            break;
                        case(Player.TombstoneType.bullet):
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
                spriteRenderer.color = Color.blue;
                break;   
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
        for (int i = 0; i < 360; i += 90)
        {
            GameObject b = Instantiate(bulBullet, this.transform.position, Quaternion.identity);
            b.gameObject.SendMessage("MakeGo", i);
            yield return new WaitForSeconds(0.5f);
        }
        bulCanFire = true;
    }

    IEnumerator RadSpawnCooldown()
    {
        radCanSpawnGhost = false;
        cirlce.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(radGhostInitDelay);
        cirlce.GetComponent<SpriteRenderer>().enabled = false;
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
