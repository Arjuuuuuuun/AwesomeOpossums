using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public static AudioSource[] aud = new AudioSource[2];
    [SerializeField] GameObject heartbeatg;
    AudioSource heartbeat;
    // Start is called before the first frame update
    void Awake()
    {
        heartbeat = heartbeatg.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((Player.health - 10f) / 10f);
        heartbeat.volume = (10f - Player.health)  / 10f;
        
    }
}
