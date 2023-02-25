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
            case (2):

                break;
        }

    }

    private void Update()
    {
    }

    void Tutur1()
    {
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
    }

    IEnumerator Level1()
    {

        while (true) { };

        //BEGIN LEVEL 1
        yield return new WaitForSeconds(4);


        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 0, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 1, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(4);

        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 2, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 1, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(4);

        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 3, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 0, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(4);

        yield return new WaitForSeconds(8);

        for (int i = 0; i < 2; ++i)
        {
            Instantiate(infantry, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
            Debug.Log("Infantry Spawned");
            yield return new WaitForSeconds(2f);
        }

    }
}
