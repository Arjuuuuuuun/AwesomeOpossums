using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private bool is_wave_started;
    public GameObject tutorialText;

    private void Start()
    {
        is_wave_started = false;
    }
    void Update()
    {
        switch (HeadManager.instance.level_counter)
        {
            case 0:
                
                break;

        }
    }
}
