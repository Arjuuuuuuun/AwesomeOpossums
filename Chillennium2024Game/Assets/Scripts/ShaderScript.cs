using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScrpit : MonoBehaviour
{
    [SerializeField] UnityEngine.Shader shade;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam =  GetComponent<Camera>();
    }

    void GreyOn()
    {
        cam.SetReplacementShader(shade,"");
    }

    void GreyOff()
    {
        cam.ResetReplacementShader();
    }

}
