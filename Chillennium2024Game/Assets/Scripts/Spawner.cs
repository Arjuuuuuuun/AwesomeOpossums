using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int direction;

    private Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        StartLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartLevel(int level)
    {
        switch(level)
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

    IEnumerator LevelOne()
    {
        

        while (true)
        {
            GameObject enemy = Instantiate(this.enemy);
            enemy.SendMessage("Rotate", direction);
            enemy.transform.position = transform.position;
            yield return new WaitForSeconds(3);
        }
    }
}
