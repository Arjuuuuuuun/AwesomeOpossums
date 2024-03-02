using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrey : MonoBehaviour
{

    [SerializeField] Shader shade;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Material mat = new Material(shade);
            this.gameObject.GetComponent<SpriteRenderer>().material = mat;
        }
        catch (Exception e) { 
            Debug.Log(e.Message);
        }
    }

}
