using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTombstone : Tombstone
{

    bool canFire = true;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    [SerializeField] float timeBeforeFirstFire;

    override protected void Activate()
    {
        if (canFire)
        {
            StartCoroutine(Fire());
        }
    }
    IEnumerator Fire()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        for (int i = 0; i < 360; i += 90)
        {
            GameObject b = Instantiate(bullet, this.transform.position, Quaternion.identity);
            b.gameObject.SendMessage("MakeGo", i);
            yield return new WaitForSeconds(0.5f);
        }
        canFire = true;
    }

}
