using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SimpleSeter : MonoBehaviour
{
    public Transform toSet;

    private void Awake()
    {
        if(toSet == null) toSet = transform;
    }

    public void SetPosition(Vector3 newPos)
    {
        toSet.position = newPos;
    }

    public void SetRotation(Quaternion rot)
    {
        toSet.rotation = rot;
    }

    public void SetScale(Vector3 scale)
    {
        toSet.localScale = scale;
    }

}
