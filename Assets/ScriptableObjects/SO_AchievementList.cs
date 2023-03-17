using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SO_", menuName = "Data/Achievement")]
public class SO_AchievementList : ScriptableObject
{
    public List<Achievement> allAchievements;
    public UnityEvent<Achievement> OnNewAchievementUnlocked;
    public UnityEvent<string> OnUpdateAch;

    //private List<string> unlocked = new List<string>();
    //private Dictionary<string,Achievement> achievements = new Dictionary<string, Achievement>();

    public void UnlockAchievement(string id, int round)
    {
        Achievement toUnlockAch = GetAchievementById(id);
        if (toUnlockAch != null)
        {
            //Debug.Log("length: " + unlocked.Count );
            if (!IsAchivementUnlocked(toUnlockAch))
            {
                OnNewAchievementUnlocked?.Invoke(toUnlockAch);
            }

            toUnlockAch.isUnlocked = true;
            OnUpdateAch?.Invoke(id);
            toUnlockAch.maxRound = Mathf.Max(toUnlockAch.maxRound,round);

            //Debug.Log("Already have the achievement '" + id + "'");
        }
        else Debug.Log("Achievement '" + id + "' is not found");
        
    }

    public bool IsAchivementUnlocked(string id)
    {
        return GetAchievementById(id).isUnlocked;
    }
    public bool IsAchivementUnlocked(Achievement ach)
    {
        return ach.isUnlocked;
    }


    public Achievement GetAchievementById(string id)
    {
        foreach (var achievement in allAchievements)
        {
            if(achievement.id == id)
            {
                return achievement;
            }
        }
        return null;
    }

    public void ClearUnlocks()
    {
        foreach (var item in allAchievements)
        {
            //item.isUnlocked = false;
            item.clean();
        }
        OnUpdateAch?.Invoke("_all"); // _all call for everyones
    }

    public void UnlockAll()
    {
        foreach (var item in allAchievements)
        {
            item.isUnlocked = true;
        }
        OnUpdateAch?.Invoke("_all");
    }
}
