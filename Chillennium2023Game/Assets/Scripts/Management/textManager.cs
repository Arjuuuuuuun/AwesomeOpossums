using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{


    public Text tutorial_text;
    
    private bool is_fox_bought;
    private bool is_camel_bought;
    private bool is_wave_1_started;

    private bool isWaiting;

    private void Start()
    {
        is_wave_1_started = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (HeadManager.instance.tutorial_counter)
        {
            case (1):
                tutorial_text.text = "Ah, a tomb with a heart! Protect your son against incoming spirits.";
                if (!is_wave_1_started)
                {
                    is_wave_1_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("Tutur1");
                    StartCoroutine(Wait());
                }             
                break;

            case (2):
                tutorial_text.text = "Be careful! Enemies also deplete your life force!";
                break;

            case (3):
                tutorial_text.text = "Camels can block projectiles, use them to protect yourself and your minions!";
                if (is_camel_bought)
                {
                    GameObject.Find("EnemySpawner").SendMessage("StartLevel1");
                    ++HeadManager.instance.tutorial_counter;
                }
                break;
            case (4):
                tutorial_text.text = "Killing enemies gives you more life force, defeat the enemy base to win!!";
                break;
        }
    }

    void FoxBought()
    {
        is_fox_bought = true;
    }

    void CamelBought()
    {
        is_camel_bought = true;
    }

    IEnumerator Wait()
    {
        if (isWaiting)
        {

        }
        else
        {
            isWaiting = true;
            yield return new WaitForSeconds(5);
            isWaiting = false;
            ++HeadManager.instance.tutorial_counter;
        }
    }
}
