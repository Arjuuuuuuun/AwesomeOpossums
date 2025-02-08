using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] levelSelectButtons = new Button[6];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelSelectButtons.Length; i++)
        {
            if (i == 0)
            {
                levelSelectButtons[i].enabled = false;
            }
            else
            {
                levelSelectButtons[i].enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
