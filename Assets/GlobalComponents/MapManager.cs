using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapManager : MonoBehaviour
{

    [SerializeField] private SO_AchievementList _AchievementList;

    // list of all objects on the map with the achievable script
    private List<C_Achievable> AchievableList;

    public UnityEvent<string> OnNewNB;
    private int nb = 0;


    private void Start()
    {
        AchievableList = AxelUtils.FindObjectsImplementingInterface<C_Achievable>(true);
    }

    public void OnPlayerWin()
    {

        nb = -1;

        // unlock new achievements
        if (AchievableList != null)
        {
            nb += 1;
            foreach (var item in AchievableList)
            {
                if (item.objToActivate.activeSelf)
                {
                    //print("unlocked " + item.achievementId);
                    _AchievementList.UnlockAchievement(item.achievementId);
                    nb++;
                }
                //else print("already unlocked " + item.achievementId);
            }
        }
        
        var obj = FindSpawnable();
        if(obj != null)
        {
            obj.SetActive(true);
        }

        OnNewNB?.Invoke(nb.ToString());
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
        AchievableList.Shuffle();
        foreach (var item in AchievableList)
        {
            if (item.objToActivate.activeSelf)
            {
                item.objToActivate.SetActive(false);
            }
        }

    }


}
