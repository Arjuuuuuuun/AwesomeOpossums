using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centre : MonoBehaviour
{
    private[SerializeField] float destructionRadius = 5f;

    public void TakeDamage(int damage)
    {
       GameObject.Find("Player").SendMessage("TakeDamage", damage);
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
}
