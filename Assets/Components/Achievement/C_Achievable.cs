using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class C_Achievable : MonoBehaviour
{
    public string achievementId = "None";
    public GameObject objToActivate;
    public GameObject objToActivateElite;

    public Dictionary<GameMode,GameObject> objs = new Dictionary<GameMode, GameObject>();

    private void Awake()
    {
        if(objToActivate != null)
            objs.Add(GameMode.Normal, objToActivate);
        if(objToActivateElite != null)
            objs.Add(GameMode.Elite, objToActivateElite);
    }

    public bool isActive(GameMode mode)
    {
        if(objs.TryGetValue(mode, out GameObject obj))
        {
            if (obj != null)
                return obj.activeSelf;
            else Debug.LogWarning("Object is null at achievement " + achievementId + " in mode " + mode);
        }
        else Debug.LogWarning("Object is null at achievement " + achievementId + " in mode " + mode);
        
        return false;
    }

    public void activeMode(GameMode mode)
    {
        objs[mode].SetActive(true);
    }

}
