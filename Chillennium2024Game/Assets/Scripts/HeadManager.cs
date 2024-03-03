using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadManager : MonoBehaviour
{
    public static HeadManager instance;
    public static int level_counter;
    
    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        level_counter = 0;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
