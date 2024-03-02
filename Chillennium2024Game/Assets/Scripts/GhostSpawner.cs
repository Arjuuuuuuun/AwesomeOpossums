using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        SummonGhost(new Vector2(-9, 4), new Vector2(1, 0));
        SummonGhost(new Vector2(-9, 2), new Vector2(1, 0));
        SummonGhost(new Vector2(-9, 0), new Vector2(1, 0));
        SummonGhost(new Vector2(-9, -2), new Vector2(1, 0));
        SummonGhost(new Vector2(-9, -4), new Vector2(1, 0));
        yield return new WaitForSeconds(1f);
    }

    private void SummonGhost(Vector2 position, Vector2 velocity)
    {
        velocity.Normalize();
        GameObject ghost = Instantiate(this.ghost);
        ghosts.Add(ghost);
        ghost.SendMessage("init", position);
        ghost.SendMessage("init2", velocity);
    }
}
