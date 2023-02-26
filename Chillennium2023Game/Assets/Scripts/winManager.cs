using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winManager : MonoBehaviour
{
    public Text text;
    public Button button;
    private void Update()
    {
        if (HeadManager.instance.level_counter == 8)
        {
            text.text = "You Win!";
            button.transform.position = new Vector3(10000, 10000, 10000);
        }
    }


}
