using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject fox;
    public GameObject rat;
    public GameObject camel;
    private GameObject clone;
    private Transform trans;

    public void Start()
    {
        trans = GetComponent<Transform>();
    }

    public void SpawnFox()
    {
        clone = Instantiate(fox, new Vector3(trans.position.x - .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
    }

    public void SpawnRat()
    {
        clone = Instantiate(rat, new Vector3(trans.position.x - .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
    }

    public void SpawnCamel()
    {
        clone = Instantiate(camel, new Vector3(trans.position.x - .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
    }
}
