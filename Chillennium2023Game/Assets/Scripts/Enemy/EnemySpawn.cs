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
    void StartLevel1()
    {
        StartCoroutine(Level1());
    }

    IEnumerator Level1()
    {

        //BEGIN LEVEL 1
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 0, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 1, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(6);

        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 2, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 1, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(6);

        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 3, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 0, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(10);

        HeadManager.instance.level_counter = 2;
    }
}
