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

        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 3; ++i)
            {
                SpawnEnemy(list);   
                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                yield return new WaitForSeconds(1f);
                
            }
            yield return new WaitUntil(() => Player.life == Player.Life.Alive);
            yield return new WaitForSeconds(10f);
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
