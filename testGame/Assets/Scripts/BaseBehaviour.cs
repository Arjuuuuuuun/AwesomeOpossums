using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseBehaviour : MonoBehaviour
{
    public int health;
    public GameObject enemyType1;
    public GameObject enemyType2;
    public GameObject enemyType3;
    public GameObject enemyType4;
    public bool cont;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        cont = true;
    }

    // Update is called once per frame
    void Update()
    {
    }



    public IEnumerator SpawnEnemy()
    {
        //int i = 3;
        while (true)
        {
            string tag = "enemyType1";
            Debug.Log(tag);
            switch (tag)
            {
                case "enemyType1":
                    Instantiate(enemyType1, transform.position, transform.rotation);
                    break;
                case "enemyType2":
                    Instantiate(enemyType2, transform.position, transform.rotation);
                    break;
                case "enemyType3":
                    Instantiate(enemyType3, transform.position, transform.rotation);
                    break;
                case "enemyType4":
                    Instantiate(enemyType4, transform.position, transform.rotation);
                    break;
            }
            yield return new WaitForSeconds(2);
        }
        
    }
    

   /*
    public void takeDamage(int damage)
    {
        health = (health - damage < 0 ? 0 : health - damage) ;
        if(health < 0)
        {
            SceneManager.LoadScene("IntroScene");
        }
    }
   */
}
