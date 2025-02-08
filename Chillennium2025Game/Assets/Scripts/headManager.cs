using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headManager : MonoBehaviour
{
    public static headManager instance;
    public int[] level_completions = new int[4];

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        level_completions[0] = 0;
        level_completions[1] = 0;
        level_completions[2] = 0;
        level_completions[3] = 0;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
