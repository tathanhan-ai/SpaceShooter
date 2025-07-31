using UnityEngine;

public class PlayerController : Auth, IDamageable
{
    // ... các biến khác của Player
    public Bullet BulletPrefab;
    // Bắt buộc phải cài đặt TakeDamage vì đã "hứa" với interface IDamageable
    public void TakeDamage(float amount)
    {
        // Sử dụng thuộc tính CurrentHealth kế thừa từ lớp Auth
        CurrentHealth -= amount;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
        }
        Debug.Log($"Player health is now: {CurrentHealth}");
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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
            Fire();
        }
    }
}