using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tombstone : MonoBehaviour
{

    [SerializeField] protected enum TombstoneState {notActive, Active };
    TombstoneState state;

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
        state = TombstoneState.Active;
    }
    IEnumerator Fire()
    {
        canFire = false;
        GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

}
