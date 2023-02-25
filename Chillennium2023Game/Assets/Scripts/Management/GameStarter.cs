using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private void Awake()
    {
        HeadManager.instance.level_counter = 0;
    }
}
