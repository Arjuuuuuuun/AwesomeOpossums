using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private void Start()
    {
        HeadManager.instance.level_counter = 6;
        HeadManager.instance.tutorial_counter = 21;
        HeadManager.instance.kill_counter = 0;
        HeadManager.instance.is_fox_active = true;
        HeadManager.instance.is_fox_bought = false;
        HeadManager.instance.is_camel_active = true;
        HeadManager.instance.is_camel_bought = false;
        HeadManager.instance.is_powerup_active = true;
        HeadManager.instance.is_rat_active = false;
    }
}
