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
    private FlyPath _myFlyPath;
    public float FlySpeed;
    public float rotationSpeed = 10f;
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

    public void Initialize(FlyPath path)
    {
        _myFlyPath = path;
        _currentWaypointIndex = 0;
    }

    private void Move()
    {
        // Di chuyển dựa trên đường bay riêng _myFlyPath
        if (_myFlyPath == null || _myFlyPath.Waypoints.Length == 0)
        {
            return;
        }

        Transform targetWaypoint = _myFlyPath.Waypoints[_currentWaypointIndex].transform;
        Vector3 direction = targetWaypoint.position - transform.position;
        if (direction != Vector3.zero) 
        {

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        float step = FlySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= _myFlyPath.Waypoints.Length)
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
