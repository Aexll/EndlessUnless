using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_RandomPrefab : MonoBehaviour
{
    public List<GameObject> prefabs;
    public UnityEvent<GameObject> OnSelectPrefab;

    public void SelectRandom()
    {
        if(prefabs != null)
        {
            prefabs.Shuffle();
            OnSelectPrefab?.Invoke(prefabs[0]);
        }
    }
}
