using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    [SerializeField] private Button b;
    void Update(){b.interactable = !Spawner.in_level;}
}
