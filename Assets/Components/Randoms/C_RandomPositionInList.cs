using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_RandomPositionInList : MonoBehaviour
{
    public List<Vector3> positions;
    public UnityEvent<Vector3> OnPositionSelected;

    public void SelectRandom()
    {
        if(positions != null)
        {
            positions.Shuffle();
            OnPositionSelected?.Invoke(positions[0]);
        }
    }
}
