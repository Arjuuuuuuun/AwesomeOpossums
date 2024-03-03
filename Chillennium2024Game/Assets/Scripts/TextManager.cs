using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private bool is_wave_started;
    private bool is_red_tower_built;
    private bool delay = false;
    private bool inDelay = false;
    public static bool readyForLevel2 = false;
    public static bool readyForLevel4 = false;
    public TMP_Text tutorialText;
    public Button button;
    private void Start()
    {
        is_wave_started = false;
        is_red_tower_built = false;
    }
    void Update()
    {
        switch (HeadManager.instance.text_counter)
        {
            case 0:
                tutorialText.text = "Welcome! Use the WASD keys to move";
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    HeadManager.instance.text_counter = 1;
                }
                break;
            case 1:
                tutorialText.text = "Press space next to a tombstone to distrub the spirits inside, activating it";
                if (is_red_tower_built)
                {
                    HeadManager.instance.text_counter = 2;
                    if (!inDelay)
                    {
                        StartCoroutine(Delay(4));
                    }
                }
                break;
            case 2:
                tutorialText.text = "Active tombstones loose there health over time, reactivate them whenever you please!";
                if (delay)
                {
                    delay = false;
                    HeadManager.instance.text_counter = 3;
                    readyForLevel2 = true;
                }
                break;
            case 3:
                tutorialText.text = "<-- Press Next Level to began the ritual and start the wave";
                if (is_wave_started)
                {
                    HeadManager.instance.text_counter = 4;
                    if (!inDelay)
                    {
                        is_wave_started = false;
                        StartCoroutine(Delay(4));
                    }
                }
                break;
            case 4:
                tutorialText.text = "Watch out! disturbed spirits can harm both you and the sheriffs";
                if (delay)
                {
                    delay = false;
                    HeadManager.instance.text_counter = 5;
                }

                break;
            case 5:
                tutorialText.text = "Your life is tied to both you and your ritual site, protect them both.";
                if (HeadManager.instance.level_counter == 2)
                {
                    HeadManager.instance.text_counter = 6;
                    if (!inDelay)
                    {
                        StartCoroutine(Delay(6));
                    }
                }
                break;
            case 6:
                button.interactable = false;
                tutorialText.text = "When all your lives are lost, vengeful spirits will hunt your soul until balance is restored.";
                if (delay)
                {
                    delay = false;
                    HeadManager.instance.text_counter = 7;
                }
                break;
            case 7:
                button.interactable = true;
                tutorialText.text = "As long as you can avoid the spirits you will be brought back with a new life, Hang in there!";
                if (is_wave_started)
                {
                    HeadManager.instance.text_counter = 8;
                }
                break;
            case 8:
                tutorialText.text = "Be careful! More sheriffs are coming from both sides";
                if(HeadManager.instance.level_counter == 3)
                {
                    HeadManager.instance.text_counter = 9;
                }
                break;
            case 9:
                button.interactable = false;
                tutorialText.text = "Press '2' to switch tombstone mode. This will allow you to activate them different color.";
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    HeadManager.instance.text_counter = 10;
                    if (!inDelay)
                    {
                        StartCoroutine(Delay(6));
                    }
                }
                break;
            case 10:
                button.interactable = false;
                tutorialText.text = "You can press '1' and '2' to switch between the modes at will!";
                if (delay)
                {
                    delay = false;
                    HeadManager.instance.text_counter = 11;
                }
                break;
            case 11:
                tutorialText.text = "Good luck out there, more sheriffs spotted";
                if (HeadManager.instance.level_counter == 4)
                {
                    HeadManager.instance.text_counter = 12;
                    if (!inDelay)
                    {
                        StartCoroutine(Delay(4));
                    }
                }
                break;
            case 12:
                button.interactable = false;
                tutorialText.text = "Next wave will have priests that block all red bullets!";
                if (delay)
                {
                    delay = false;
                    HeadManager.instance.text_counter = 13;
                }
                break;
            case 13:
                tutorialText.text = "Its only geting harder from here!";
                if (HeadManager.instance.level_counter == 5)
                {
                    HeadManager.instance.text_counter= 14;
                }
                break;

        }
    }
    IEnumerator Delay(float time)
    {
        inDelay = true;
        yield return new WaitForSeconds(time);
        delay = true;
        inDelay = false;    
    }
    void RedTowerBuild()
    {
        is_red_tower_built = true;
    }
    void StartWave()
    {
        is_wave_started = true;
    }
}
