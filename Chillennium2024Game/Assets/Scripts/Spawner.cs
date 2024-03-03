using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject priest;
    GameObject headManager;
    public static bool in_level;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel(HeadManager.instance.level_counter);
    }

   

    void StartLevel(int level)
    {
        in_level = true;
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

    void SpawnEnemyRight(ref List<GameObject> enemyList)
    {
        GameObject enemy = Instantiate(this.enemy);
        enemy.SendMessage("Rotate", 1);
        enemy.transform.position = transform.position;
        enemyList.Add(enemy);
    }
    void SpawnEnemyLeft(ref List<GameObject> enemyList)
    {
        GameObject enemy = Instantiate(this.enemy);
        enemy.SendMessage("Rotate", 2);
        enemy.transform.position = new Vector3(-10.57f,-0.75f,0);
        enemyList.Add(enemy);
    }

    void SpawnPriestRight(ref List<GameObject> enemyList)
    {
        GameObject enemy = Instantiate(this.priest);
        enemy.SendMessage("Rotate", 1);
        enemy.transform.position = transform.position;
        enemyList.Add(enemy);
    }
    void SpawnPriestLeft(ref List<GameObject> enemyList)
    {
        GameObject enemy = Instantiate(this.priest);
        enemy.SendMessage("Rotate", 2);
        enemy.transform.position = new Vector3(-10.57f, -0.75f, 0);
        enemyList.Add(enemy);
    }


    void StopCos()
    {
        StopAllCoroutines();
    }

    IEnumerator LevelOne()
    {
        yield return new WaitUntil(() => TextManager.readyForLevel2);
        yield return new WaitUntil(() => Player.life == Player.Life.Alive);
        in_level = false;
        ++HeadManager.instance.level_counter;
    }
    IEnumerator LevelTwo()
    {
      
        List<GameObject> list = new List<GameObject>();

        for (int i = 0; i < 5; ++i)
        {

                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemyRight(ref list);
                yield return new WaitForSeconds(2f);

        }
            while (true)
            {
                int num_alive = 0;
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i] != null)
                    {
                        Debug.Log(list[i].name);
                        num_alive++;
                        break;
                    }
                }
                if (num_alive == 0)
                    break;
                yield return new WaitForSeconds(2);

            }


        yield return new WaitUntil(() => Player.life == Player.Life.Alive);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("GhostBullet");
        foreach (GameObject bullet in bullets)
        {
            GameObject.Destroy(bullet);
        }
        in_level = false;
        ++HeadManager.instance.level_counter;
    }


    IEnumerator LevelThree()
    {

        List<GameObject> list = new List<GameObject>();
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < 6; ++i)
            {

                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemyRight(ref list);
                SpawnEnemyLeft(ref list);
                yield return new WaitForSeconds(2f);

            }
            yield return new WaitForSeconds(6f);
        }
        while (true)
        {
            int num_alive = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] != null)
                {
                    Debug.Log(list[i].name);
                    num_alive++;
                    break;
                }
            }
            Debug.Log(num_alive);
            if (num_alive == 0)
                break;
            yield return new WaitForSeconds(2);

        }
        yield return new WaitUntil(() => Player.life == Player.Life.Alive);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("GhostBullet");
        foreach (GameObject bullet in bullets)
        {
            GameObject.Destroy(bullet);
        }
        ++HeadManager.instance.level_counter;
        in_level = false;
    }

    IEnumerator LevelFour()
    {

        List<GameObject> list = new List<GameObject>();

        for(int i = 0; i < 4; ++i)
        {

                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemyLeft(ref list);
                SpawnEnemyRight(ref list);
                yield return new WaitForSeconds(1f);
            
        }
        yield return new WaitUntil(() => Player.life == Player.Life.Alive);
        yield return new WaitForSeconds(12f);

        for (int i = 0; i < 6; ++i)
        {

                yield return new WaitUntil(() => Player.life == Player.Life.Alive);
                SpawnEnemyRight(ref list);
                SpawnEnemyLeft(ref list);
                yield return new WaitForSeconds(2f);

        }
        yield return new WaitUntil(() => Player.life == Player.Life.Alive);
        yield return new WaitForSeconds(13f);

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
        yield return new WaitUntil(() => Player.life == Player.Life.Alive);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("GhostBullet");
        foreach (GameObject bullet in bullets)
        {
            GameObject.Destroy(bullet);
        }
        ++HeadManager.instance.level_counter;
        in_level = false;
    }
}
