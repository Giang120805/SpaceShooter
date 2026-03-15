using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint = 10;

    public int healthPoint;

    // Event
    public System.Action onDead;
    public System.Action onHealthChanged;

    private void Start()
    {
        healthPoint = defaultHealthPoint;

        // cập nhật UI lúc bắt đầu
        onHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        Debug.Log(gameObject.name + " HP: " + healthPoint);

        // cập nhật thanh máu
        onHealthChanged?.Invoke();

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

        onDead?.Invoke();

        Destroy(gameObject);
    }
}