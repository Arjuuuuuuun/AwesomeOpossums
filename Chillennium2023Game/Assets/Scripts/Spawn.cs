using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject spirit;
    private GameObject clone;
    private Transform trans;


    public void Start()
    {
        trans = GetComponent<Transform>();
        StartCoroutine(Wave1());
    }

    IEnumerator Wave1()
    {

        //BEGIN LEVEL 1
        yield return new WaitForSeconds(2);

        for (int i = 0; i < 3; ++i)
        {
            clone = Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
            yield return new WaitForSeconds(2);
        }

    }
}
