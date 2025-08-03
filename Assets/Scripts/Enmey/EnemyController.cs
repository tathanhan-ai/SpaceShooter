using GluonGui.WorkspaceWindow.Views.WorkspaceExplorer;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
public class EnemyController : Auth,IDamageable
{
    private float damage = 1;
    public BallEnmey BallEnmeyPrefab;
    private float m_ballTime;
    public Transform healthBarForeground;
    public EnemyWave EnemyWave;
    public float FlySpeed;
    private Vector3 initialHealthBarScale;
    private int _currentWaypointIndex = 0;
    Score m_scoreManager;

    private void Start()
    {
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

    public void Move()
    {
        float step = FlySpeed * Time.deltaTime;
        Transform targetWaypoint = EnemyWave.FlyPath.Waypoints[_currentWaypointIndex].transform;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= EnemyWave.FlyPath.Waypoints.Length)
            {
                _currentWaypointIndex = 0;
            }
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

    public void Die()
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
        Move();
        Fire();
    }

    private void UpdateHealthBar()
    {
        if (healthBarForeground == null) return;
        float healthPercent = (float)CurrentHealth / MaxHealth;
        healthBarForeground.localScale = new Vector3(initialHealthBarScale.x * healthPercent,initialHealthBarScale.y,initialHealthBarScale.z);
    }
}
