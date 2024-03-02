using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTombstone : Tombstone
{
    bool canSpawnGhost = true;
    [SerializeField] GameObject ghost;
    [SerializeField] float ghostSpawnRate;
    protected override void Activate()
    {
        if (canSpawnGhost){ 
            StartCoroutine(SpawnCooldown()); }
    }

    IEnumerator SpawnCooldown()
    {
        canSpawnGhost = false;
        yield return new WaitForSeconds(ghostSpawnRate);
        GameObject b = Instantiate(ghost, new Vector2(transform.position.x + 1.25f,transform.position.y - 1.25f), Quaternion.identity);
        canSpawnGhost = true; 
    }
}
