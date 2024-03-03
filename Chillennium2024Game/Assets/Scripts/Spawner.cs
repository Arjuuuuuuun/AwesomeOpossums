using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int direction;
    GameObject headManager;
    [SerializeField] private bool isRightSpawner;

    // Start is called before the first frame update
    void Start()
    {
        headManager = GameObject.FindGameObjectWithTag("HeadManager");
        StartLevel(HeadManager.level_counter);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartLevel(int level)
    {
        switch (level)
        {
            case 0:
                StartCoroutine("LevelOne");
                break;
            case 1:
                StartCoroutine("LevelTwo");
                break;
            case 2:
                StartCoroutine("LevelThree");
                break;
            case 3:
                StartCoroutine("LevelFour");
                break;
            case 4:
                StartCoroutine("LevelFive");
                break;

        }
    }

    void SpawnEnemy(ArrayList enemyList)
    {
        GameObject enemy = Instantiate(this.enemy);
        enemy.SendMessage("Rotate", direction);
        enemy.transform.position = transform.position;
        enemyList.Add(enemy);
    }
    IEnumerator LevelOne()
    {

        ArrayList list = new ArrayList();

        for (int i = 0; i < 5; ++i)
        {
            if (isRightSpawner)
            {
                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemy(list);
                yield return new WaitForSeconds(2f);
            }
        }
        while (true)
        {
            int num_alive = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] != null)
                {
                    num_alive++;
                    break;
                }
            }
            Debug.Log("Num Alive");
            if (num_alive == 0)
                break;
            yield return new WaitForSeconds(2);

        }

        Debug.Log("Level one Complete");
        //headManager.SendMessage("LevelComplete");
    }
    IEnumerator LevelThree()
    {

        ArrayList list = new ArrayList();

        for(int i = 0; i < 5; ++i)
        {
            if (isRightSpawner)
            {
                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemy(list);
                yield return new WaitForSeconds(2f);
            }
        }
        yield return new WaitUntil(() => Player.life == Player.Life.Alive);
        yield return new WaitForSeconds(6f);

        for (int i = 0; i < 5; ++i)
        {

                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemy(list);
                yield return new WaitForSeconds(2f);

        }


        for (int j = 0; j < 7; j++)
        {
            for (int i = 0; i < 5; ++i)
            {
                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemy(list);   
                yield return new WaitForSeconds(1f);
                
            }
            yield return new WaitUntil(() => Player.life == Player.Life.Alive);
            yield return new WaitForSeconds(4f);
        }

        for(int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j % 2 == 0 && isRightSpawner)
                {
                    yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                    SpawnEnemy(list);
                    yield return new WaitForSeconds(0.5f);
                }
                else if (j % 2 == 1 && !isRightSpawner)
                {
                    yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                    SpawnEnemy(list);
                    yield return new WaitForSeconds(1f);
                }
            }
            yield return new WaitUntil(() => Player.life == Player.Life.Alive);
            yield return new WaitForSeconds(5 - i / 4);

        }
        while (true)
        {
            int num_alive = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] != null) { 
                    num_alive++; 
                    break; 
                }
            }
            if (num_alive == 0) 
                break; 
            yield return new WaitForSeconds(2);

        }


        headManager.SendMessage("LevelComplete");
    }
}
