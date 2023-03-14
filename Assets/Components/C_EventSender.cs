using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_EventSender : MonoBehaviour
{

    [Tooltip("Use '|' to uses multiples tags in one send")]
    [SerializeField] string tags;

    public void Send(GameObject go)
    {
        var er = go.GetComponent<C_EventReciver>();
        if (er != null) Send(er);
    }

    public void Send(C_EventReciver er)
    {
        er.Recive(tags);
    }
}
