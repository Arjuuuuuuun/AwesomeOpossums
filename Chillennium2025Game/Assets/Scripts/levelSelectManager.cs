using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] levelSelectButtons = new Button[12];
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        levelSelectButtons[0].enabled = false;
        if (headManager.instance.level_completions[0] == 1)
        {
            levelSelectButtons[1].enabled = false;
        }
        if (headManager.instance.level_completions[1] == 1)
        {
            levelSelectButtons[2].enabled = false;
        }
        if (headManager.instance.level_completions[2] == 1)
        {
            levelSelectButtons[3].enabled = false;
        }
        if (headManager.instance.level_completions[3] == 1)
        {
            for (int i = 0; i < levelSelectButtons.Length; i++)
            {
                levelSelectButtons[i].enabled = false;
            }
        }
    }
}
