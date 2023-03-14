using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_RandomRotationInList : MonoBehaviour
{
    public List<float> rotationsAngle;
    public UnityEvent<float> OnRotationSelected;

    public void SelectRandom()
    {
        if(rotationsAngle != null)
        {
            rotationsAngle.Shuffle();
            OnRotationSelected?.Invoke(rotationsAngle[0]);
        }
    }
}
