using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private bool is_wave_started;
    private bool is_red_tower_built;
    private bool delay = false;
    private bool inDelay = false;
    public static bool readyForLevel2 = false;
    public static bool readyForLevel4 = false;
    public TMP_Text tutorialText;

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
                tutorialText.text = "<-- Press new wave to began the ritual and start the wave";
                if (is_wave_started)
                {
                    HeadManager.instance.text_counter = 4;
                    if (!inDelay)
                    {
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
                tutorialText.text = "Your life force is tied to both yourself and the ritual site, make sure to protect them both.";
                if (HeadManager.instance.level_counter == 2)
                {
                    HeadManager.instance.text_counter = 6;
                }
                break;
            case 6:
                tutorialText.text = "Watch out!  When all your lives are lost, vengeful spirits will hunt your soul until balance is restored.  Hang in there!";
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
