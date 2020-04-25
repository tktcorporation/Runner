using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    //[SerializeField]
    //float speed = 4;
    //[SerializeField]
    //int spriteCount = 2; //背景オブジェクトの横の数

    float width;
    float xMiddleWidth;
    SpriteRenderer sprite;
    Camera camera;

    //初期化
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        width = sprite.bounds.size.x;
        xMiddleWidth = width / 4;
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        float xPosition = sprite.transform.position.x;
        DirectionMap direction = getDirectionToReplace(xPosition, xMiddleWidth);
        if (direction == DirectionMap.center)
            return;
        transform.position = new Vector2(calculateTargetPositionX(xPosition, xMiddleWidth, direction), sprite.transform.position.y);
    }

    private float calculateTargetPositionX(float xPosition, float xMiddleWidth, DirectionMap direction)
    {
        return xPosition + ((int)direction * xMiddleWidth);
    }

    private DirectionMap getDirectionToReplace(float xPosition, float xMiddleWidth)
    {
        float xCameraPosition = camera.transform.position.x;
        if (xCameraPosition > calculateTargetPositionX(xPosition,xMiddleWidth, DirectionMap.front))
            return DirectionMap.front;
        if (xCameraPosition < calculateTargetPositionX(xPosition, xMiddleWidth, DirectionMap.back))
            return DirectionMap.back;
        return DirectionMap.center;
    }

    private enum DirectionMap : int {
        front = 1,
        back = -1,
        center = 0

    }
}