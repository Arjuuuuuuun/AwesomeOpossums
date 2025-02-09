using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] levelSelectButtons = new Button[12];
    // Start is called before the first frame update

    [SerializeField] private Sprite[] levelLocked = new Sprite[12];
    [SerializeField] private Sprite[] levelUnlocked = new Sprite[12];
    [SerializeField] private Sprite[] levelCompleted = new Sprite[12];
    private void Awake()
    {
        {
            for (int i = 0; i < levelSelectButtons.Length; i++)
            {
                levelSelectButtons[i].enabled = false;
                levelSelectButtons[i].image.sprite = levelLocked[i];
            }
            levelSelectButtons[0].image.sprite = levelUnlocked[0];
        }
    }
    // Update is called once per frame
    void Update()
    {

        levelSelectButtons[0].enabled = true;
        if (headManager.instance.level_completions[0] == 1)
        {
            levelSelectButtons[0].image.sprite = levelCompleted[0];
            levelSelectButtons[1].image.sprite = levelUnlocked[1];
            levelSelectButtons[1].enabled = true;
        }
        if (headManager.instance.level_completions[1] == 1)
        {
            levelSelectButtons[1].image.sprite = levelCompleted[1];
            levelSelectButtons[2].image.sprite = levelUnlocked[2];
            levelSelectButtons[2].enabled = true;
        }
        if (headManager.instance.level_completions[2] == 1)
        {
            levelSelectButtons[2].image.sprite = levelCompleted[2];
            levelSelectButtons[3].image.sprite = levelUnlocked[3];
            levelSelectButtons[3].enabled = true;
        }
        if (headManager.instance.level_completions[3] == 1)
        {
            levelSelectButtons[3].image.sprite= levelCompleted[3];
            for (int i = 0; i < levelSelectButtons.Length; i++)
            {
                if (headManager.instance.level_completions[i] == 1)
                {
                    levelSelectButtons[i].image.sprite = levelCompleted[i];
                }
                else
                {
                    levelSelectButtons[i].image.sprite = levelUnlocked[i];
                }
                levelSelectButtons[i].enabled = true;
            }
        }
    }
}
