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
        SummonGhost(new Vector2(-9, 5), new Vector2(1, 0));
        SummonGhost(new Vector2(-9, 2), new Vector2(1, 0));
        SummonGhost(new Vector2(-9, -1), new Vector2(1, 0));
        SummonGhost(new Vector2(-9, -4), new Vector2(1, 0));
        yield return new WaitForSeconds(1f);
        SummonGhost(new Vector2(9, 3.5f), new Vector2(-1, 0));
        SummonGhost(new Vector2(9, 0.5f), new Vector2(-1, 0));
        SummonGhost(new Vector2(9, -2.5f), new Vector2(-1, 0));
        SummonGhost(new Vector2(9, -5.5f), new Vector2(-1, 0));
        yield return new WaitForSeconds(1f);
        SummonGhost(new Vector2(9, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(6, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(3, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(0, 5.5f), new Vector2(-1, -1));
        yield return new WaitForSeconds(1f);
        SummonGhost(new Vector2(-9, 5.5f), new Vector2(1, -1));
        SummonGhost(new Vector2(-6, 5.5f), new Vector2(1, -1));
        SummonGhost(new Vector2(-3, 5.5f), new Vector2(1, -1));
        SummonGhost(new Vector2(-0, 5.5f), new Vector2(1, -1));
        yield return new WaitForSeconds(1f);
        SummonGhost(new Vector2(9, -5.5f), new Vector2(-1, 1));
        SummonGhost(new Vector2(6, -5.5f), new Vector2(-1, 1));
        SummonGhost(new Vector2(3, -5.5f), new Vector2(-1, 1));
        SummonGhost(new Vector2(0, -5.5f), new Vector2(-1, 1));
        yield return new WaitForSeconds(1f);
        SummonGhost(new Vector2(-9, -5.5f), new Vector2(1, 1));
        SummonGhost(new Vector2(-6, -5.5f), new Vector2(1, 1));
        SummonGhost(new Vector2(-3, -5.5f), new Vector2(1, 1));
        SummonGhost(new Vector2(-0, -5.5f), new Vector2(1, 1));
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 12; i++)
        {
            SummonGhost(new Vector2(10 *Mathf.Cos(i*30), 10 * Mathf.Sin(i * 30)), new Vector2(-10 * Mathf.Cos(i * 30), -10 * Mathf.Sin(i * 30)));
        }
        yield return new WaitForSeconds(0.5f);
        SummonGhost(new Vector2(15, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(12, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(9, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(6, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(3, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(0, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(-3, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(-6, 5.5f), new Vector2(-1, -1));
        SummonGhost(new Vector2(-9, 5.5f), new Vector2(-1, -1));
    }

    private void SummonGhost(Vector2 position, Vector2 velocity)
    {
        velocity.Normalize();
        velocity *= 2f;
        GameObject ghost = Instantiate(this.ghost);
        ghosts.Add(ghost);
        ghost.SendMessage("init", position);
        ghost.SendMessage("init2", velocity);
    }
}