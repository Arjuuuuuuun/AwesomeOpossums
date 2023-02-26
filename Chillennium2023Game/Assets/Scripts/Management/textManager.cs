using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{


    public Text tutorial_text;

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

            case (0):
                tutorial_text.text = "Ah, a tomb with a heart! Use the \'w\' and \'s\' keys to move up and down.";
                if (Input.GetKeyDown("w"))
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (1):
                tutorial_text.text = "Protect your son against incoming spirits by blocking their path.";
                if (!is_wave_1_started)
                {
                    is_wave_1_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("Tutur1");
                    StartCoroutine(Wait(5));
                }             
                break;

            case (2):
                tutorial_text.text = "You can summon helpful spirits to help absorb minions!";
                StartCoroutine(Wait(4));
                break;

            case (3):
                tutorial_text.text = "Press \'1\' to buy a bear!";
                HeadManager.instance.is_fox_active = true;
                if (HeadManager.instance.is_fox_bought)
                {
                    GameObject.Find("EnemySpawner").SendMessage("StartLevel1");
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (4):
                tutorial_text.text = "Survive the level to win!";
                if (HeadManager.instance.level_counter == 2)
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (5):
                tutorial_text.text = "Press \'3\' to buy an elephant! Elephants, unlike bears can absorb projectiles.";
                HeadManager.instance.is_camel_active = true;
                if (HeadManager.instance.is_camel_bought)
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (6):
                tutorial_text.text = "Manage Projec";
                break;
        }
    }

    void CamelBought()
    {
        is_camel_bought = true;
    }

    IEnumerator Wait(float time)
    {
        if (isWaiting)
        {

        }
        else
        {
            isWaiting = true;
            yield return new WaitForSeconds(time);
            isWaiting = false;
            ++HeadManager.instance.tutorial_counter;
        }
    }
}
