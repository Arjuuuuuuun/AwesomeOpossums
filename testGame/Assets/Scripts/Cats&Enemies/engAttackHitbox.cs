using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engAttackHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(death());
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
