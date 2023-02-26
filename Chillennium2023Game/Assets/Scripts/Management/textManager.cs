using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{


    public Text tutorial_text;

    private bool is_wave_started;

    private bool isWaiting;

    private void Start()
    {
        is_wave_started = false;
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
                if (!is_wave_started)
                {
                    is_wave_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("Tutur1");
                    StartCoroutine(Wait(5));
                }             
                break;

            case (2):
                tutorial_text.text = "You can summon helpful spirits to help block minions!";
                is_wave_started = false;
                StartCoroutine(Wait(4));
                break;

            case (3):
                tutorial_text.text = "Press \'1 (One)\' to buy a bear! Bears cost 20 money. (Buy a bear to continue)";
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
                tutorial_text.text = "You can spend the heart\'s life force to use power-ups to turn the tide of battle!";
                StartCoroutine(Wait(7));
                break;

            case (6):
                tutorial_text.text = "Press \'f\' to send out a massive wall of fire! (Buy the wall of fire to continue)";
                HeadManager.instance.is_powerup_active = true;
                if (!is_wave_started)
                {
                    is_wave_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("Tutur1");
                }
                if (Input.GetKeyDown("f"))
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (7):
                tutorial_text.text = "The wall of fire costs 1 life, and damages EVERYTHING, including your own forces!";
                is_wave_started = false;
                StartCoroutine(Wait(2));
                break;

            case (8):
                if (!is_wave_started)
                {
                    is_wave_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("Tutur2");
                    StartCoroutine(Wait(10));
                }
                break;

            case (9):
                tutorial_text.text = "You can also drain the heart\'s life to gain more money by pressing \'r\'.";
                is_wave_started = false;
                StartCoroutine(Wait(12));
                break;

            case (10):
                if (!is_wave_started)
                {
                    is_wave_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("StartLevel2");
                    StartCoroutine(Wait(12));
                }
                break;

            case (11):
                tutorial_text.text = "Remember, you can block enemies!";
                if (HeadManager.instance.level_counter == 3)
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (12):
                tutorial_text.text = "Press \'3\' to buy an elephant! (Buy an elephant to continue)";
                HeadManager.instance.is_camel_active = true;
                HeadManager.instance.is_fox_active = false;
                HeadManager.instance.is_powerup_active = false;
                GameManager.canGainMoney = false;
                PlayerBase.canMove = false;
                if (HeadManager.instance.is_camel_bought)
                {
                    ++HeadManager.instance.tutorial_counter;
                    GameObject.Find("EnemySpawner").SendMessage("StartLevel3");
                }
                break;

            case (13):
                tutorial_text.text = "Projectiles will only be stopped by elephants, unlike bears, so watch out!";
                PlayerBase.canMove = true;
                GameManager.canGainMoney = true;
                HeadManager.instance.is_fox_active = true;
                HeadManager.instance.is_powerup_active = true;
                StartCoroutine(Wait(12));
                break;

            case (14):
                tutorial_text.text = "Wall of Fire also destroys projectiles!";
                if (HeadManager.instance.level_counter == 4)
                {
                    is_wave_started = false;
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (15):
                tutorial_text.text = "The phraoh is not holding back..., power up use is the key to victory.";
                if (!is_wave_started)
                {
                    is_wave_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("StartLevel4");
                }
                StartCoroutine(Wait(12));
                break;

            case (16):
                tutorial_text.text = "The phraoh is starting to show his true power!";
                if (HeadManager.instance.level_counter == 5)
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;
            
            case (17):
                tutorial_text.text = "Press \'2\' to summon an earth of foxes. (Buy some foxes to continue)";
                GameManager.canGainMoney = false;
                HeadManager.instance.is_camel_active = false;
                HeadManager.instance.is_fox_active = false;
                HeadManager.instance.is_powerup_active = false;
                HeadManager.instance.is_rat_active = true;
                if (Input.GetKeyDown("2"))
                {
                    ++HeadManager.instance.tutorial_counter;
                    GameObject.Find("EnemySpawner").SendMessage("Tutur1");
                }
                break;

            case (18):
                tutorial_text.text = "Foxes are very weak, but press \'e\' to detonate them for massive damage!";
                is_wave_started = false;
                GameManager.canGainMoney = true;
                HeadManager.instance.is_camel_active = true;
                HeadManager.instance.is_fox_active = true;
                HeadManager.instance.is_powerup_active = true;
                StartCoroutine(Wait(10));
                break;

            case (19):
                tutorial_text.text = "Remeber to use your power ups!";
                if (!is_wave_started)
                {
                    is_wave_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("StartLevel5");
                    StartCoroutine(Wait(10));
                }
                break;

            case (20):
                tutorial_text.text = "You have learned everything now, the pharoh will soon show no mercy.";
                if (HeadManager.instance.level_counter == 6)
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (21):
                tutorial_text.text = "Good luck on the upcoming trials!";
                if (!is_wave_started)
                {
                    is_wave_started = true;
                    GameObject.Find("EnemySpawner").SendMessage("StartLevel6");
                    StartCoroutine(Wait(10));
                }
                break;

            case (22):
                tutorial_text.text = "It\'s impressive you made it this far...";
                if (HeadManager.instance.level_counter == 7)
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;
        }
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

