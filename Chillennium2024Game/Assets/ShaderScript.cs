using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScrpit : MonoBehaviour
{
    [SerializeField] UnityEngine.Shader shade;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = new Material(shade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
