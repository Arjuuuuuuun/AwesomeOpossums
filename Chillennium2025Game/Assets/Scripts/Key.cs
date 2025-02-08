using UnityEngine;

public class Key : MonoBehaviour
{
    public float speed = 2f; // Controls the speed of oscillation
    public float scaleFactor = 1f; // How much it shrinks during rotation

    void Update()
    {
        float scale = Mathf.Sin(Time.time * speed) * scaleFactor; // Oscillate between -scaleFactor and +scaleFactor
        transform.localScale = new Vector3(scale, 1, 1); // Change X-scale to simulate 3D rotation
    }
}
