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
    public float size = 1;
    public bool isUnlocked = false;
    public bool isDescriptionLocked = false;
    //public List<AchievementModifier> modifiers = new List<AchievementModifier>();
    public int maxRound = 0;
    public GameMode gameMode;
    [HideInInspector] public UnityEvent<bool> OnUnlock;

    public void clean()
    {
        isUnlocked = false;
        maxRound = 0;
    }
}
