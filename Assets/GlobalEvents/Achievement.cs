using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Achievement{
    public string id = "None";
    public string name = "Default";
    public string description = "Default";
    public Color color = Color.white;
    public Sprite img;
    public Sprite bg;
    public float size = 1;
    public bool isUnlocked = false;
    public bool isDescriptionLocked = false;
    [HideInInspector] public UnityEvent<bool> OnUnlock;
}
