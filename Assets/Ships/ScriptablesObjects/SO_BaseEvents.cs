using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



//[CreateAssetMenu(fileName = "Et_", menuName = "NewEvents/EventTemplate")]
public class SO_BaseEvent<T> : ScriptableObject
{
    public UnityEvent<T> Event;
}

[CreateAssetMenu(fileName = "Ei_", menuName = "Events/Int")]
public class SO_IntEvent : SO_BaseEvent<int> { }

[CreateAssetMenu(fileName = "Ef_", menuName = "Events/Float")]
public class SO_FloatEvent : SO_BaseEvent<float> { }

[CreateAssetMenu(fileName = "Es_", menuName = "Events/String")]
public class SO_StringEvent : SO_BaseEvent<string> { }

