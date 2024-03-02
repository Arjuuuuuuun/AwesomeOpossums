using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrey : MonoBehaviour
{

    [SerializeField] Shader shade;
    Material org;
    // Start is called before the first frame update
    private void Start()
    {
        org = this.gameObject.GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        if (Player.life == Player.Life.Dead)
        {
            try
            {
                Material mat = new Material(shade);
                this.gameObject.GetComponent<SpriteRenderer>().material = mat;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }

        else
        {
            try
            {
                this.gameObject.GetComponent<SpriteRenderer>().material = org;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }

}
