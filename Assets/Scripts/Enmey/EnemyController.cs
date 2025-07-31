using UnityEngine;

public class EnemyController : Auth,IDamageable
{
    private float damage = 1;
    public BallEnmey BallEnmeyPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(damage);
    }

    public override void Fire()
    {
        Instantiate(BallEnmeyPrefab, transform.position, transform.rotation);
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

    private void Update()
    {
        Fire();
    }
}
