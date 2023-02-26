using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{

    public GameObject spirit;
    public GameObject infantry;
    public GameObject exploder;
    private Transform trans;


    public void Start()
    {
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
        //trans = GetComponent<Transform>();
        //switch (HeadManager.instance.level_counter)
        //{
        //    case (2):
        //        Instantiate(infantry, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
        //        break;
        //}

    }

    //void Tutur1()
    //{
    //    Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y, trans.position.z), Quaternion.identity, trans);
    //}
    //void StartLevel1()
    //{
    //    StartCoroutine(Level1());
    //}

    //IEnumerator Level1()
    //{

    //    //BEGIN LEVEL 1
    //    Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 0, trans.position.z), Quaternion.identity, trans);
    //    Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 1, trans.position.z), Quaternion.identity, trans);
    //    yield return new WaitForSeconds(6);

    //    Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 2, trans.position.z), Quaternion.identity, trans);
    //    Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 1, trans.position.z), Quaternion.identity, trans);
    //    yield return new WaitForSeconds(6);

    //    Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 3, trans.position.z), Quaternion.identity, trans);
    //    Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 0, trans.position.z), Quaternion.identity, trans);
    //    yield return new WaitForSeconds(10);

    //    HeadManager.instance.level_counter = 2;
    //    SceneManager.LoadScene(1);

    //}
}
