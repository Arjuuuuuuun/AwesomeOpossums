using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    [SerializeField] GameObject LevelThemeg;
    [SerializeField] GameObject Heartbeatg;
    AudioSource Heartbeat;
    AudioSource LevelTheme;
    // Start is called before the first frame update
    void Awake()
    {   
        LevelTheme = LevelThemeg.GetComponent<AudioSource>();
        Heartbeat = Heartbeatg.GetComponent<AudioSource>();
        Heartbeat.Play();
        LevelTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((Player.health - 10f) / 10f);
        Heartbeat.volume = (10f - Player.health)  / 10f;
        
    }
}
