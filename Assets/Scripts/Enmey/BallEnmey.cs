using UnityEngine;

public class BallEnmey : MonoBehaviour
{
    public float Flyspeed = -10f;

    // Update is called once per frame
    void Update()
    {
        var newPosition = transform.position;
        newPosition.y = Flyspeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
