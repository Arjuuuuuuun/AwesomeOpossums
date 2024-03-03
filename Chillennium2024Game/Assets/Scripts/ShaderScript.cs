using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScrpit : MonoBehaviour
{
    [SerializeField] UnityEngine.Shader shade;
    Camera cam;
    Material mat;
    [SerializeField] GameObject square;
    // Start is called before the first frame update
    void Start()
    {
        cam =  GetComponent<Camera>();
        mat = new Material(shade);
    }

    void Damage(){
        StartCoroutine(Flash());

    }
    IEnumerator Flash()
    {
        //cam.SetReplacementShader(shade, "");
        square.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.2f);
        square.transform.position = new Vector3(1000f, 1000f, 1000f);
        //cam.ResetReplacementShader();
    }

}
