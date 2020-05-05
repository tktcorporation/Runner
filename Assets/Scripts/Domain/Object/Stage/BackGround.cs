using System;
using UnityEngine;
namespace Object.Stage
{
    public class BackGround : Base
    {
        Camera camera;
        float xMiddleWidth;
        public BackGround(
            SpriteRenderer sprite,
            Camera camera,
            int magnifications
        ) : base(sprite.transform)
        {
            this.camera = camera;
            this.xMiddleWidth = sprite.bounds.size.x / magnifications;
        }
        public void CheckCameraPositionAndUpdate()
        {
            float xPosition = transform.position.x;
            DirectionMap direction = GetDirectionToReplace(xPosition, xMiddleWidth);
            if (direction == DirectionMap.center)
                return;
            ChangePosition(
                new Vector3(
                    CalculateTargetPositionX(xPosition, xMiddleWidth, direction),
                    transform.position.y,
                    transform.position.z
                )
            );
        }
        float CalculateTargetPositionX(float xPosition, float xMiddleWidth, DirectionMap direction)
        {
            return xPosition + ((int)direction * xMiddleWidth);
        }
        DirectionMap GetDirectionToReplace(float xPosition, float xMiddleWidth)
        {
            float xCameraPosition = camera.transform.position.x;
            if (xCameraPosition > CalculateTargetPositionX(xPosition, xMiddleWidth, DirectionMap.front))
                return DirectionMap.front;
            if (xCameraPosition < CalculateTargetPositionX(xPosition, xMiddleWidth, DirectionMap.back))
                return DirectionMap.back;
            return DirectionMap.center;
        }
    }
    enum DirectionMap : int
    {
        front = 1,
        back = -1,
        center = 0
    }
}

