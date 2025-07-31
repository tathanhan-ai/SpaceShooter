using UnityEngine;

public class Auth : MonoBehaviour
{
    public float MaxHealth;

    // 'protected set' cho phép các lớp con (như PlayerController) có thể thay đổi giá trị này
    public float CurrentHealth { get; protected set; }

    protected virtual void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void Move()
    {
        // Logic di chuyển mặc định (nếu có)
    }

    public virtual void Fire()
    {
        // Logic bắn mặc định (nếu có)
    }

    public virtual void Die()
    {
        // Logic bắn mặc định (nếu có)
    }
}