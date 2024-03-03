using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScrpit : MonoBehaviour
{
    [SerializeField] UnityEngine.Shader shade;
    Camera cam;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        cam =  GetComponent<Camera>();
        mat = new Material(shade);
    }

    void Damage(){
        //StartCoroutine(Flash());

    }
    IEnumerator Flash()
    {
        cam.SetReplacementShader(shade, "");
        yield return new WaitForSeconds(0.2f);
        cam.ResetReplacementShader();
    }

}
