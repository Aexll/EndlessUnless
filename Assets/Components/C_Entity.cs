using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Entity : MonoBehaviour, IResetable
{

    public bool isTemporary = false;
    private Vector3 DefaultPosition;
    private Quaternion DefaultRotation;
    private Vector3 DefaultScale;

    private void Awake()
    {
        DefaultPosition= transform.position;
        DefaultRotation= transform.rotation;
        DefaultScale= transform.localScale;
    }

    public void Reseting()
    {
        if(isTemporary) Destroy(gameObject);
        transform.position = DefaultPosition;
        transform.rotation = DefaultRotation;
        transform.localScale= DefaultScale;
    }

    public void ResetAll()
    {
        IResetable[] toReset = gameObject.GetComponentsInChildren<IResetable>();
        foreach (var item in toReset)
        {
            item.Reseting();
        }
    }
}
