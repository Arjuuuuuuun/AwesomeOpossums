using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private void Start()
    {
        HeadManager.instance.level_counter = 2;
        HeadManager.instance.tutorial_counter = 5;
        HeadManager.instance.is_fox_active = true;
        HeadManager.instance.is_fox_bought = false;
        HeadManager.instance.is_camel_active = true;
        HeadManager.instance.is_camel_bought = false;
    }
}
