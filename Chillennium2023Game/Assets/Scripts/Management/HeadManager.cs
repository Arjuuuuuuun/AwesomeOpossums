using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadManager : MonoBehaviour
{
    public static HeadManager instance;
    public int level_counter;
    public int tutorial_counter;
    public bool is_fox_active;
    public bool is_fox_bought;
    public bool is_camel_active;
    public bool is_camel_bought;
    public bool is_powerup_active;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
