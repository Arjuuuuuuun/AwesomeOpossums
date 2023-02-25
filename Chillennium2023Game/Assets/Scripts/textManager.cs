using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{

    public Text tutorial_text;
    private int counter = 0;

    private void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (counter)
        {
            case (0):
                tutorial_text.text = "Welcome";
                break;
        }
    }
}
