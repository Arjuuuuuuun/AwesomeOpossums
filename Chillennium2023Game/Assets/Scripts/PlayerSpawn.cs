using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject fox;
    public GameObject rat;
    public GameObject camel;
    public GameObject beam;
    private Transform trans;

    public void Start()
    {
        trans = GetComponent<Transform>();
    }

    public void SpawnFox()
    {
        HeadManager.instance.is_fox_bought = true;
        Instantiate(fox, new Vector3(trans.position.x, trans.position.y + ((PlayerBase.level - 1)* 1.75f), trans.position.z), Quaternion.identity, trans);
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
            Instantiate(rat, new Vector3(trans.position.x, trans.position.y + ((PlayerBase.level - 1) * 1.75f), trans.position.z), Quaternion.identity, trans);
        }
    }

    public void SpawnCamel()
    {
        HeadManager.instance.is_camel_bought = true;
        Instantiate(camel, new Vector3(trans.position.x, trans.position.y + ((PlayerBase.level - 1) * 1.75f), trans.position.z), Quaternion.identity, trans);
    }

    void SpawnBeam()
    {
        Instantiate(beam, new Vector3(trans.position.x, 0, trans.position.z), Quaternion.identity, trans);
    }
}
