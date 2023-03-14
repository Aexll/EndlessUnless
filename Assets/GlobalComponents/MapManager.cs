using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapManager : MonoBehaviour
{

    [SerializeField] private SO_AchievementList _AchievementList;

    // list of all objects on the map with the achievable script
    private List<C_Achievable> AchievableList; 


    private void Start()
    {
        AchievableList = AxelUtils.FindObjectsImplementingInterface<C_Achievable>(true);
    }

    public void OnPlayerWin()
    {

        if (AchievableList != null)
        {
            foreach (var item in AchievableList)
            {
                if (item.objToActivate.activeSelf)
                {
                    //print("unlocked " + item.achievementId);
                    _AchievementList.UnlockAchievement(item.achievementId);
                }
                //else print("already unlocked " + item.achievementId);
            }
        }
        
        var obj = FindSpawnable();
        if(obj != null)
        {
            obj.SetActive(true);
        }
    }

    private GameObject FindSpawnable()
    {
        AchievableList.Shuffle();
        foreach (var item in AchievableList)
        {
            if (!item.objToActivate.activeSelf)
            {
                return item.objToActivate;
            }
        }
        return null;
    }

    public void CleanAchievements()
    {
        _AchievementList.ClearUnlocks();
    }

    public void CleanAllSpawned()
    {
    }


}
