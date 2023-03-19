using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllObjects : MonoBehaviour
{
    public void ResetAll()
    {

        List<IResetable> toReset = AxelUtils.FindObjectsImplementingInterface<IResetable>();
        foreach (var item in toReset)
        {
            item.Reseting();
        }
        
    }
}
