using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tombstone : MonoBehaviour
{

    [SerializeField] protected enum TombstoneState {notActive, Active };
    TombstoneState state;
    [SerializeField] float tombstoneAwakeTime;

    bool canFire;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    bool playerNear;

    private SpriteRenderer spriteRenderer;
   
    void Start()
    {
        state = TombstoneState.notActive;
        spriteRenderer = GetComponent<SpriteRenderer>();
        canFire = true;
    }

    void Update()
    {

        switch (state) {
            case TombstoneState.notActive:
                spriteRenderer.color = Color.gray;
                if (playerNear && Input.GetKeyDown(KeyCode.Space))
                {
                   StartCoroutine(ActiveTimer());
                }
                break;
            case TombstoneState.Active:
                spriteRenderer.color = Color.blue;
                if (canFire){
                    spriteRenderer.color = Color.red;
                    StartCoroutine(Fire());
                }
                break;   
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Detected");
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
        Debug.Log("Activtating Tombstone");
        state = TombstoneState.Active;
        yield return new WaitForSeconds(tombstoneAwakeTime);
        state = TombstoneState.notActive;
    }
    IEnumerator Fire()
    {
        canFire = false;
        //GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

}
