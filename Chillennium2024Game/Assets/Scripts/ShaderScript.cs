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
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination,material);
    }
}
