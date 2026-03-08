using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    // Đếm số enemy còn sống
    public static int LivingEnemyCount;

    private void Awake()
    {
        LivingEnemyCount++;
    }

    protected override void Die()
    {
        LivingEnemyCount--;

        base.Die();

        Debug.Log("Enemy died");
    }
}