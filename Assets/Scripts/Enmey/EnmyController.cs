using UnityEngine;

public class EnmyController : Auth,IDamageable
{
    private float damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(damage);
    }
    private void Die()
    {
        Destroy(gameObject);
    }

    private void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
}
