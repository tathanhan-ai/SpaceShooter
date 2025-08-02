using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public FlyPath FlyPath;
    public int Quantity;
    public EnemyController EnemyPrefab;
    public float InitializationTime = 3;
    public float DelayTime;
    private float m_InInitializationTime;

    public void Start()
    {
        m_InInitializationTime = InitializationTime;
    }
    public void Update()
    {
        DelayTime -= Time.deltaTime;
        if (DelayTime <= 0) { 
        m_InInitializationTime -= Time.deltaTime;
        if(Quantity > 0 && m_InInitializationTime <= 0)
        {
            m_InInitializationTime = InitializationTime;
            Instantiate(EnemyPrefab, FlyPath.Waypoints[0].transform.position, FlyPath.Waypoints[0].transform.rotation);
            Quantity--;
        }
        }
    }
}
