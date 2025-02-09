using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class sounQueueWhenNearGhost : MonoBehaviour
{

    PostProcessVolume ppVolume;
    LensDistortion ppLens;
    audioManager audioManager;
    [SerializeField] float distanceWhenSoundQueueIsPlayed;
    int ghostsNear = 0;
    bool soundQueuePlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        ppVolume = GetComponentInChildren<PostProcessVolume>();
        ppVolume.profile.TryGetSettings<LensDistortion>(out ppLens);
        audioManager = FindObjectOfType<audioManager>();
    }


    private void Update()
    {

        var ghosts = FindObjectsOfType<GhostScript>();
        bool nearGhost = false;
        foreach(var ghost in ghosts)
        {
            if(Vector2.Distance(ghost.gameObject.transform.position,this.transform.position) < distanceWhenSoundQueueIsPlayed)
            {
                nearGhost = true;
             

                if (soundQueuePlayed == false)
                {
                    audioManager.SendMessage("raiseHeartbeat");
                    Debug.Log("Ghost Near");
                    soundQueuePlayed = true;
                }
            }
        }
        if(nearGhost == false)
        {
            soundQueuePlayed = false;
            audioManager.SendMessage("lowerHeartbeat");
            Debug.Log("Ghost Away");
        }
    }
    
}
