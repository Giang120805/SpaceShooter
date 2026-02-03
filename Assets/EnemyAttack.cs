using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(9999); // enemy tự chết
            }
        }
    }
}