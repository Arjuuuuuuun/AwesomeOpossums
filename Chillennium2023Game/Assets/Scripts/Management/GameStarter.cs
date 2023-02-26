using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private void Start()
    {
        HeadManager.instance.level_counter = 3;
        HeadManager.instance.tutorial_counter = 12;
        HeadManager.instance.is_fox_active = false;
        HeadManager.instance.is_fox_bought = false;
        HeadManager.instance.is_camel_active = false;
        HeadManager.instance.is_camel_bought = false;
        HeadManager.instance.is_powerup_active = false;
    }
}
