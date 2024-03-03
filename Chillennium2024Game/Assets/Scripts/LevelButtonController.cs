using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    private Button b;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        b.enabled = !Spawner.in_level;
        Debug.Log(b.enabled ? "enabled" : "not enabled");
    }
}
