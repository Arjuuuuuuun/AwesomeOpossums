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
        Spawn('s', 1);
    }

    void Tutur2()
    {
        Spawn('s', 3);
        Spawn('s', 4);
        Spawn('s', 1);
    }


    void StartLevel1()
    {
        StartCoroutine(Level1());
    }

    void StartLevel2()
    {
        StartCoroutine(Level2());
    }

    void StartLevel3()
    {
        StartCoroutine(Level3());
    }

    void StartLevel4()
    {
        StartCoroutine(Level4());
    }

    void StartLevel5()
    {
        StartCoroutine(Level5());
    }

    void StartLevel6()
    {
        StartCoroutine(Level6());
    }
    void StartLevel7()
    {
        StartCoroutine(Level7());
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

        StartCoroutine(waitUntilKillCount(6));

    }

    IEnumerator Level2()
    {

        //BEGIN LEVEL 2
        Spawn('s', 4);
        Spawn('s', 1);
        yield return new WaitForSeconds(5);

        Spawn('s', 4);
        Spawn('s', 3);
        Spawn('s', 2);
        yield return new WaitForSeconds(5);

        Spawn('s', 4);
        Spawn('s', 1);
        Spawn('s', 2);
        yield return new WaitForSeconds(10);

        StartCoroutine(waitUntilKillCount(8));

    }

    IEnumerator Level3()
    {
        //BEGIN LEVEL 3
        Spawn('i', 1);
        yield return new WaitForSeconds(5);
        
        Spawn('s', 4);
        yield return new WaitForSeconds(10);

        Spawn('i', 4);
        Spawn('s', 2);


        StartCoroutine(waitUntilKillCount(4));
    }

    IEnumerator Level4()
    {
        Spawn('s', 1);
        Spawn('s', 4);
        yield return new WaitForSeconds(5);

        Spawn('s', 3);
        Spawn('i', 3);
        yield return new WaitForSeconds(5);

        Spawn('s', 2);

        StartCoroutine(waitUntilKillCount(5));

    }

    IEnumerator Level5()
    {
        Spawn('s', 2);
        Spawn('s', 1);
        yield return new WaitForSeconds(12);

        Spawn('i', 4);
        Spawn('s', 3);
        yield return new WaitForSeconds(12);

        for(int i = 1; i <= 4; ++i)
        {
            Spawn('s', i);
            yield return new WaitForSeconds(1.5f);
        }

        yield return new WaitForSeconds(5);

        for (int i = 1; i <= 4; ++i)
        {
            Spawn('s', i);
            yield return new WaitForSeconds(1.5f);
        }


        for (int i = 4; i >= 1; --i)
        {
            Spawn('s', i);
            yield return new WaitForSeconds(1.5f);
        }

        StartCoroutine(waitUntilKillCount(17));

    }

    IEnumerator Level6()
    {
        for (int i = 2; i <= 4; ++i)
        {
            Spawn('s', i);
            yield return new WaitForSeconds(3f);
        }
        Spawn('i', 2);
        yield return new WaitForSeconds(8);

        for (int i = 2; i <= 4; ++i)
        {
            Spawn('i', i);
            yield return new WaitForSeconds(4f);
            Spawn('s', i);
        }

        yield return new WaitForSeconds(12);

        Spawn('s', 2);
        Spawn('i', 3);
        Spawn('s', 1);

        yield return new WaitForSeconds(12);

        Spawn('s', 3);
        Spawn('i', 4);
        Spawn('s', 1);

        yield return new WaitForSeconds(14);
        for (int i = 3; i <= 4; ++i)
        {
            Spawn('i', i);
            yield return new WaitForSeconds(4f);
            Spawn('s', i);
        }

        StartCoroutine(waitUntilKillCount(21));
    }

    IEnumerator Level7()
    {
        for(int i = 1; i <=4; ++i)
        {
            Spawn('s', i);
            yield return new WaitForSeconds(1.75f);
        }
        Spawn('i', 2);
        Spawn('i', 3);
        yield return new WaitForSeconds(4);

        for(int i = 1; i <= 4; ++i)
        {
            Spawn('i', i);
            yield return new WaitForSeconds(1.5f);
            Spawn('s', i);
        }

        yield return new WaitForSeconds(12);

        Spawn('s', 4);
        Spawn('i', 1);
        Spawn('s', 2);
        Spawn('i', 3);

        yield return new WaitForSeconds(5);

        Spawn('s', 3);
        Spawn('i', 4);
        Spawn('s', 1);
        Spawn('i', 2);

        yield return new WaitForSeconds(10);
        for (int i = 1; i <= 4; ++i)
        {
            Spawn('i', i);
            Spawn('i', 4);
            yield return new WaitForSeconds(3f);
            Spawn('s', i);
        }

        StopCoroutine(waitUntilKillCount(34));

    }

    IEnumerator waitUntilKillCount(int val)
    {
        yield return new WaitUntil(() => HeadManager.instance.kill_counter >= val);
        ++HeadManager.instance.level_counter;
        HeadManager.instance.kill_counter = 0;
        SceneManager.LoadScene(2);
    }
}
