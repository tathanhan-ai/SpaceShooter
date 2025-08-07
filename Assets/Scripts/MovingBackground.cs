using UnityEngine;
using UnityEngine.UIElements;

public class MovingBackground : MonoBehaviour
{
    public Transform[] BackGrounds;
    public float MovingSpeed = -1f;
    private float _backGroundHeight;
    private float _cameraBottomEdge;

    private void Start()
    {
        _backGroundHeight = BackGrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
        _cameraBottomEdge = Camera.main.transform.position.y - Camera.main.orthographicSize;
    }

    private void Update()
    {
        foreach ( var backGround in BackGrounds) { 
        var bgPos = backGround.transform.position;
        bgPos.y += MovingSpeed * Time.deltaTime;
        backGround.transform.position = bgPos;

        if (bgPos.y + _backGroundHeight / 2 < _cameraBottomEdge) {
            var topBG = GetTheTopBG();
            backGround.transform.position = new Vector3(bgPos.x, topBG + _backGroundHeight, bgPos.z);


        }
        }
    }
    private float GetTheTopBG()
    {
        var maxPos = 0f;
        foreach (var backGround in BackGrounds)
        {
            if ( maxPos < backGround.transform.position.y)
            {
                maxPos = backGround.transform.position.y;
            }
        }
        return maxPos;
    }
}
