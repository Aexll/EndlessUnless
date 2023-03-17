using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GetPositionTick : MonoBehaviour
{
    public Vector3c position;

    void Update()
    {
        position.Value = transform.position;
    }
}
