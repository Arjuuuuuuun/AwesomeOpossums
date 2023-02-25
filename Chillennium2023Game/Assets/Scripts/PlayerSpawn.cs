using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject fox;
    public GameObject rat;
    public GameObject camel;
    private Transform trans;

    public void Start()
    {
        trans = GetComponent<Transform>();
    }

    public void SpawnFox()
    {
        HeadManager.instance.is_fox_bought = true;
        Instantiate(fox, new Vector3(trans.position.x, trans.position.y, trans.position.z), Quaternion.identity, trans);
    }

    public void SpawnRat()
    {
        StartCoroutine(SpawnRats());
    }

    IEnumerator SpawnRats()
    {
        for (int i = 0; i < 3; ++i)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(rat, new Vector3(trans.position.x, trans.position.y, trans.position.z), Quaternion.identity, trans);
        }
    }

    public void SpawnCamel()
    {
        Instantiate(camel, new Vector3(trans.position.x, trans.position.y, trans.position.z), Quaternion.identity, trans);
    }
}
