using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headManager : MonoBehaviour
{
    public static headManager instance;
    public int[] level_completions = new int[12];

    [SerializeField] private sceneManager sceneManager;

    private void Awake()
    {
        sceneManager.RunSlides();

        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
