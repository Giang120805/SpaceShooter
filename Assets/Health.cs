using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint = 10;

    protected int healthPoint;

    // thêm event khi chết
    public System.Action onDead;

    protected virtual void Start()
    {
        healthPoint = defaultHealthPoint;
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;
        Debug.Log(gameObject.name + " HP: " + healthPoint);

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );
            Destroy(explosion, 1f);
        }

        // gọi event khi object chết
        onDead?.Invoke();

        Destroy(gameObject);
    }
}