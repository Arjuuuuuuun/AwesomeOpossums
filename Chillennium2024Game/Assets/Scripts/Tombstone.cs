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
    public void Activate()
    {
        if (state == TombstoneState.notActive)
        {
            StartCoroutine(ActiveTimer());
        }
    }
    IEnumerator ActiveTimer()
    {
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
