using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Broadcaster : MonoBehaviour
{
    public SO_Action ToBoradcast;

    public void Broadcast()
    {
        ToBoradcast.OnTrigger?.Invoke();
    }
}
