using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
public class EnemyController : Auth,IDamageable
{
    private float damage = 1;
    private int score;
    public BallEnmey BallEnmeyPrefab;
    private float m_ballTime;
    public Transform healthBarForeground;
    private Vector3 initialHealthBarScale;
    Score m_scoreManager;

    private void Start()
    {
        score = 0;
        m_ballTime = Random.Range(0f, 5f);
        if (healthBarForeground != null)
        {
            initialHealthBarScale = healthBarForeground.localScale;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet")) { 
        TakeDamage(damage);
        }
    }

    public override void Fire()
    {
        m_ballTime -= Time.deltaTime;
        if (m_ballTime <= 0)
        {
            Instantiate(BallEnmeyPrefab, transform.position, transform.rotation);
            m_ballTime = Random.Range(0f, 5f);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        UpdateHealthBar();
        if (CurrentHealth <= 0)
        {
            m_scoreManager = FindObjectOfType<Score>();
            m_scoreManager.AddScore(1);
            Die();

        }
    }

    private void Update()
    {
        Fire();
    }

    private void UpdateHealthBar()
    {
        if (healthBarForeground == null) return;
        float healthPercent = (float)CurrentHealth / MaxHealth;
        healthBarForeground.localScale = new Vector3(initialHealthBarScale.x * healthPercent,initialHealthBarScale.y,initialHealthBarScale.z);
    }
}
