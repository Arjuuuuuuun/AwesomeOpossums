using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadManager : MonoBehaviour
{
    public static HeadManager instance;
    public int level_counter;
    public int text_counter;
    
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        level_counter = 0;
        text_counter = 0;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
