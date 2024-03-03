using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private bool is_wave_started;
    private bool is_red_tower_built;
    public TMP_Text tutorialText;

    private void Start()
    {
        is_wave_started = false;
        is_red_tower_built = false;
    }
    void Update()
    {
        switch (HeadManager.instance.level_counter)
        {
            case 0:
                tutorialText.text = "Use the WASD keys to move!";
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    HeadManager.instance.level_counter = 1;
                }
                break;
            case 1:
                tutorialText.text = "Press space next to a tombstone to build a red tower";
                if (is_red_tower_built)
                {
                    HeadManager.instance.level_counter = 2;
                }
                break;
            case 2:
                tutorialText.text = "<-- Press new wave to start wave";
                break;

        }
    }

    void RedTowerBuild()
    {
        is_red_tower_built = true;
    }
}
