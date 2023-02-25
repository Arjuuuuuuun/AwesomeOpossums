using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject spirit;
    public GameObject infantry;
    public GameObject exploder;
    private Transform trans;


    public void Start()
    {
        trans = GetComponent<Transform>();
        switch (HeadManager.instance.level_counter)
        { 
            case (1):
                StartCoroutine(Level1());
                break;
        }
    }

    IEnumerator Level1()
    {

        //BEGIN LEVEL 1
        yield return new WaitForSeconds(2);

        for (int i = 0; i < 2; ++i)
        {
            Instantiate(infantry, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
            Debug.Log("Infantry Spawned");
            yield return new WaitForSeconds(2);
        }

        yield return new WaitForSeconds(4);

        for (int i = 0; i < 4; ++i)
        {
            Instantiate(infantry, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
            Debug.Log("Infantry Spawned");
            yield return new WaitForSeconds(1.5f);
        }

    }
}
