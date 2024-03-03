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
    [SerializeField] GameObject bulBulletFurth;
    [SerializeField] float bulFireRate;
    [SerializeField] float bulTimeBeforeFirstFire;
   

    [SerializeField] private GameObject skull;

    private Animator anime;
    [SerializeField] private Sprite flameless_skull;

    // Health
    public SpriteRenderer healthBar;

    private Vector3 HealthStartingPosition = new Vector3(0,-0.7f,0);


    private float maxHealth = 100;
    private float currentHealth;

    //Audio
    [SerializeField] private AudioClip build;


    private void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;

        // Update the color of the health bar from green to red based on health percentage
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);

        if (currentHealth <= 0)
        {
            // Set the alpha value of the color to make the image transparent
            Color currentColor = healthBar.color;
            currentColor.a = 0.0f; // Set the alpha to 50% (0.0 to 1.0, where 0 is fully transparent and 1 is fully opaque)
            healthBar.color = currentColor;
        }
        else
        {
            // Update the scale (width) of the health bar
            healthBar.gameObject.transform.localScale = new Vector3(healthPercentage, .25f, 1f);

            // Calculate the intended change in position
            float newPositionX = (healthPercentage - 1) / 2 * HealthStartingPosition.x ;

            // Add the intended change to the current local position
            healthBar.gameObject.transform.localPosition = new Vector3(HealthStartingPosition.x + newPositionX, HealthStartingPosition.y, HealthStartingPosition.z);
        }
    }


    void Start()
    {

        anime = skull.GetComponent<Animator>();
        anime.enabled = false;
        skull.GetComponent<SpriteRenderer>().sprite = flameless_skull;

        state = TombstoneState.notActive;
        Color color = healthBar.color;
        color.a = 0.0f;
        healthBar.color = color;
        currentHealth = maxHealth;

    }

    void Update()
    {
        switch (state) {
            case TombstoneState.notActive:
                Color color = healthBar.color;
                color.a = 0.0f;
                healthBar.color = color;

                anime.enabled = false;
                skull.GetComponent<SpriteRenderer>().sprite = flameless_skull;
                if (playerNear && Input.GetKeyDown(KeyCode.Space))
                {
                    AudioSource.PlayClipAtPoint(build, new Vector3(0, 0, 0));
                    StartCoroutine("ActiveTimer");
                    switch (Player.tombstone)
                    {
                        case(Player.TombstoneType.radial):
                            anime.SetBool("Colour", false); anime.enabled = true;
                            type = TowerType.Radial;
                            break;
                        case(Player.TombstoneType.bullet):
                            anime.SetBool("Colour", true); anime.enabled = true;
                            GameObject.Find("TextManager").SendMessage("RedTowerBuild");
                            type = TowerType.Bullet;
                            break;
                        case (Player.TombstoneType.follow):
                            type = TowerType.Follow;
                            break;
                    }
                }
                break;
            case TombstoneState.Active:
                if(Player.life == Player.Life.Dead)
                {
                    state = TombstoneState.notActive;
                    break;
                }
                Color color3 = healthBar.color;
                color3.a = 1.0f;
                healthBar.color = color3;
                ActivateFire();

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
        yield return new WaitForSeconds(bulTimeBeforeFirstFire);
        GameObject b = Instantiate(bulBullet, this.transform.position, Quaternion.identity);
        b.name = "Red";
        b = Instantiate(bulBulletFurth, this.transform.position, Quaternion.identity);
        b.name = "Red";
        yield return new WaitForSeconds(bulFireRate);
        bulCanFire = true;
    }

    IEnumerator RadSpawnCooldown()
    {
        radCanSpawnGhost = false;
        yield return new WaitForSeconds(radGhostInitDelay);
        GameObject b = Instantiate(radGhost, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        b.name = "Blue";
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
        for(int i = 0;i  < tombstoneAwakeTime;i++)
        {
            currentHealth -= maxHealth / tombstoneAwakeTime;
            UpdateHealthBar();
            yield return new WaitForSeconds(1);
        }
        currentHealth = maxHealth;

        state = TombstoneState.notActive;

    }


}
