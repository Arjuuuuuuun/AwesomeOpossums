using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    [SerializeField] GameObject LevelThemeg;
    [SerializeField] GameObject Heartbeatg;
    [SerializeField] GameObject DeadThemeg;
    AudioSource Heartbeat;
    AudioSource LevelTheme;
    AudioSource DeadTheme;
    // Start is called before the first frame update
    void Awake()
    {   
        LevelTheme = LevelThemeg.GetComponent<AudioSource>();
        Heartbeat = Heartbeatg.GetComponent<AudioSource>();
        DeadTheme = DeadThemeg.GetComponent<AudioSource>();
        Heartbeat.Play();
        LevelTheme.Play();
        DeadTheme.Play();
    }

    // Update is called once per frame
    void Update()
    {
        DeadTheme.timeSamples = LevelTheme.timeSamples;
        Heartbeat.timeSamples = LevelTheme.timeSamples;

        if (Player.life == Player.Life.Dead)
        {
            LevelTheme.volume = 0f;
            DeadTheme.volume = .8f;
            Heartbeat.volume = 0f;
        }
        else
        {
            LevelTheme.volume = .8f;
            DeadTheme.volume = 0f;
            Heartbeat.volume = ((2f - Player.health) / 2f) * 0.3f;
        }

    }


}
