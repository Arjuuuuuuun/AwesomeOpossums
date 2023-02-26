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
        trans = GetComponent<Transform>();
    }

    void Tutur1()
    {
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y - 1f, trans.position.z), Quaternion.identity, trans);
    }


    void StartLevel1()
    {
        StartCoroutine(Level1());
    }

    void StartLevel2()
    {
        StartCoroutine(Level2());
    }

    IEnumerator Level1()
    {

        //BEGIN LEVEL 1
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 0.75f, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y - 1f, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(6);

        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 2.5f, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y - 1f, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(6);

        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + 2.5f, trans.position.z), Quaternion.identity, trans);
        Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y - 2.75f, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(10);

        HeadManager.instance.level_counter = 2;
        SceneManager.LoadScene(1);

    }

    IEnumerator Level2()
    { 
        //BEGIN LEVEL 2
        Instantiate(infantry, new Vector3(trans.position.x + .5f, trans.position.y - 2.75f, trans.position.z), Quaternion.identity, trans);
        yield return new WaitForSeconds(10);

        HeadManager.instance.level_counter = 2;
        SceneManager.LoadScene(1);

    }
}
