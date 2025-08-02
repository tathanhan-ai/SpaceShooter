using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Waypoint[] Waypoints;
    private void OnDrawGizmos()
    {
        for (int i = 0; i < Waypoints.Length - 1; i++)
        {
            if (Waypoints[i] != null && Waypoints[i + 1] != null)
            {
                Gizmos.color = Color.yellow; // Đặt màu cho đường nối
                Gizmos.DrawLine(Waypoints[i].transform.position, Waypoints[i + 1].transform.position);
            }
        }
    }
}
