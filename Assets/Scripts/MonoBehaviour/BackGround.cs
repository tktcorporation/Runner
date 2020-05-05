using UnityEngine;

public class BackGround : MonoBehaviour
{

    //[SerializeField]
    //float speed = 4;
    //[SerializeField]
    //int spriteCount = 2; //背景オブジェクトの横の数

    Object.Stage.BackGround backGround;

    private void Start()
    {
        backGround = new Object.Stage.BackGround(
            GetComponent<SpriteRenderer>(),
            Camera.main,
            4
        );
    }

    private void LateUpdate()
    {
        backGround.CheckCameraPositionAndUpdate();
    }
}