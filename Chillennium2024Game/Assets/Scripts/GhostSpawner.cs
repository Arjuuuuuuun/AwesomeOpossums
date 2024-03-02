using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{

    ArrayList ghosts = new ArrayList();
    [SerializeField] private GameObject ghost;
    // Update is called once per frame
    void Update()
    {
        if (Player.life == Player.Life.Alive)
        {
            StopAllCoroutines();
            for (int i = 0; i < ghosts.Count; i++)
            {
                GameObject.Destroy((GameObject) ghosts[i]);
            }
        }
    }

    void GhostMode()
    {
        Debug.Log("Ghost Mode");
        StartCoroutine("GhostModeSpawner");
    }

    IEnumerator GhostModeSpawner()
    {
        GameObject ghost = Instantiate(this.ghost);
        ghosts.Add(ghost);
        //ghost.SendMessage("Innit");
        yield return new WaitForSeconds(1f);
    }
}
