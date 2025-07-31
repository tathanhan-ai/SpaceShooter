using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x,mousePosition.y,0f);
    }
}
