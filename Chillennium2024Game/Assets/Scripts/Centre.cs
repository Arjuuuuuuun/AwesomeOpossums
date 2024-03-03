using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centre : MonoBehaviour
{
    [SerializeField] private float destructionRadius;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
       GameObject.Find("Player").SendMessage("TakeDamage", damage *2);
        StartCoroutine("Flash");
    }

    public void EnterDeath()
    {
        // Find all objects with the tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            // Calculate the distance between this object and the enemy
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is within the destruction radius
            if (distance <= destructionRadius)
            {
                // Destroy the enemy
                Destroy(enemy);
            }
            else
            {
                // Send a "Freeze" message to the enemy if it's outside the destruction radius
                enemy.SendMessage("Freeze");
            }
        }
    }

    IEnumerator Flash()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;

    }
}
