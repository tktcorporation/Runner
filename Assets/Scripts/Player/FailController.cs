using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailController
{
    Transform transform;
    static float failHeight = -100f;

    public FailController(Transform t)
    {
        transform = t;
    }

    public void Check()
    {
        if (!IsFailed())
            return;
        if (Manager.status == Manager.StatusMap.overed)
            return;
        transform.position = new Vector2(0, 1);
        Manager.GameOver();
    }

    private bool IsFailed()
    {
        if (transform.position.y < failHeight)
            return true;
        return false;
    }
}
