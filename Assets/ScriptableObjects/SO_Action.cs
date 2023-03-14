using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "E_", menuName = "Event/Action")]
public class SO_Action : ScriptableObject
{
    public UnityEvent OnTrigger;
}
