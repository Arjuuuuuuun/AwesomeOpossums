using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject fox;
    private GameObject clone;
    private Transform trans;

    public void Start()
    {
        trans = GetComponent<Transform>();
    }

    public void SpawnFox()
    {
        clone = Instantiate(fox, new Vector3(trans.position.x - .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
        Debug.Log("Fox Spawned");
    }
}
