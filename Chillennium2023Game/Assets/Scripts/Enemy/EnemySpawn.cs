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

    void Spawn(char type, int level)
    {
        float level_offset = -2.75f + 1.75f * (level - 1);
        switch (type)
        {
            case ('s'):
                Instantiate(spirit, new Vector3(trans.position.x + .5f, trans.position.y + level_offset, trans.position.z), Quaternion.identity, trans);
                break;
            case ('i'):
                Instantiate(infantry, new Vector3(trans.position.x + .5f, trans.position.y  +level_offset, trans.position.z), Quaternion.identity, trans);
                break;
        }
    }

    IEnumerator Level1()
    {

        //BEGIN LEVEL 1
        Spawn('s', 3);
        Spawn('s', 2);
        yield return new WaitForSeconds(6);

        Spawn('s', 4);
        Spawn('s', 2);
        yield return new WaitForSeconds(6);

        Spawn('s', 4);
        Spawn('s', 1);
        yield return new WaitForSeconds(10);

        HeadManager.instance.level_counter = 2;
        SceneManager.LoadScene(1);

    }

    IEnumerator Level2()
    {
        //BEGIN LEVEL 2
        Spawn('i', 1);
        yield return new WaitForSeconds(5);
        
        Spawn('s', 4);
        yield return new WaitForSeconds(10);

        Spawn('i', 4);
        Spawn('s', 1);
        yield return new WaitForSeconds(10);

        HeadManager.instance.level_counter = 3;
        SceneManager.LoadScene(1);

    }
}
