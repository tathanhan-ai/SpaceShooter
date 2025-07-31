using UnityEngine;

public class PlayerController : Auth, IDamageable
{
    // ... các biến khác của Player
    public Bullet BulletPrefab;
    public HealthBar healthBar;

    public void TakeDamage(float damage)
    {
        // Sử dụng thuộc tính CurrentHealth kế thừa từ lớp Auth
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // Ghi đè lại hàm Move của lớp Auth để có logic di chuyển riêng
    public override void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
    }

    // Ghi đè lại hàm Fire của lớp Auth để có logic bắn riêng
    public override void Fire()
    {
        Instantiate(BulletPrefab, transform.position, transform.rotation);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
            Fire();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BallEnemy"))
        {
            TakeDamage(1f);
            healthBar.UpdateHealthBar(1f);
        }
    }
}