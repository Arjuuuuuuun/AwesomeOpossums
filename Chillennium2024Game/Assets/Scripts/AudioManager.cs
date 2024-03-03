using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    [SerializeField] GameObject LevelThemeg;
    [SerializeField] GameObject Heartbeatg;
    [SerializeField] GameObject DeadThemeg;
    [SerializeField] GameObject IdleThemeg;
    AudioSource Heartbeat;
    AudioSource LevelTheme;
    AudioSource DeadTheme;
    AudioSource IdleTheme;
    bool swapper;
    bool swapper2;
    [SerializeField] private AudioClip invalid_build;
    // Start is called before the first frame update
    void Awake()
    {   
        LevelTheme = LevelThemeg.GetComponent<AudioSource>();
        Heartbeat = Heartbeatg.GetComponent<AudioSource>();
        DeadTheme = DeadThemeg.GetComponent<AudioSource>();
        IdleTheme = IdleThemeg.GetComponent<AudioSource>();
        IdleTheme.Play();
        swapper = false;
        swapper2 = true;
    }

    // Update is called once per frame
    void Update()
    {

        DeadTheme.timeSamples = LevelTheme.timeSamples;
        Heartbeat.timeSamples = LevelTheme.timeSamples;

        if (Spawner.in_level)
        {
            if (swapper2)
            {
                IdleTheme.Stop();
                Heartbeat.Play();
                LevelTheme.Play();
                DeadTheme.Play();
                swapper2 = false;
            }
            if (Player.life == Player.Life.Dead)
            {
                if (swapper)
                {
                    //LevelTheme.volume = 0f;
                    StartCoroutine("fadeOut", LevelTheme);
                    //DeadTheme.volume = .8f;
                    StartCoroutine("fadeIn", DeadTheme);
                    Heartbeat.volume = 0f;

                }
                swapper = false;
            }
            else
            {
                if (!swapper)
                {
                    //LevelTheme.volume = .8f;
                    StartCoroutine("fadeIn", LevelTheme);
                    //DeadTheme.volume = 0f;
                    StartCoroutine("fadeOut", DeadTheme);
                    Heartbeat.volume = ((2f - Player.health) / 2f) * 0.2f;
                }

                swapper = true;
            }
        }
        else
        {
            if (!swapper2)
            {
                IdleTheme.Play();
                Heartbeat.Stop();
                LevelTheme.Stop();
                DeadTheme.Stop();
                swapper2 = true;
            }
        }

    }

    IEnumerator fadeIn(AudioSource clip)
    {
        for (int i = 0; i < 10; ++i)
        {
            clip.volume += 0.07f;
            yield return new WaitForSeconds(.03f);
        }
        clip.volume = 0.7f;
    }

    IEnumerator fadeOut(AudioSource clip)
    {
        for (int i = 0; i < 10; ++i)
        {
            clip.volume -= 0.07f;
            yield return new WaitForSeconds(.03f);
        }
        clip.volume = 0.0f;
    }



}
