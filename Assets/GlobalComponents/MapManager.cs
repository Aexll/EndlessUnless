using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public enum GameMode
{
    Normal,
    Elite,
    Cursed,
}


public class MapManager : MonoBehaviour
{

    [SerializeField] private SO_AchievementList _AchievementList;
    [SerializeField] private GameObject Player;

    // list of all objects on the map with the achievable script
    private List<C_Achievable> AchievableList;

    public UnityEvent<string> OnNewNB;

    private int round = 0;
    GameMode gameMode = GameMode.Normal;


    private void Awake()
    {
        AchievableList = AxelUtils.FindObjectsImplementingInterface<C_Achievable>(false);
    }

    private void Start()
    {
        Player.SetActive(false);
        //PauseGame();
    }

    public void OnPlayerWin()
    {
        int nb = 0;
        // unlock new achievements
        if (AchievableList != null)
        {   
            // count
            foreach (var item in AchievableList)
            {
                if(item.isActive(gameMode))
                {
                    nb++;
                }
            }

            round = nb;

            foreach (var item in AchievableList)
            {
                if(item.isActive(gameMode))
                {
                    string finalId = item.achievementId;
                    if (gameMode == GameMode.Elite) finalId += "(e)";
                    else if (gameMode == GameMode.Cursed) finalId += "(c)";
                    print(finalId);
                    _AchievementList.UnlockAchievement(finalId, round);
                }
            }
        }
        
        var obj = FindSpawnable(gameMode);
        if(obj != null)
        {
            obj.SetActive(true);
        }

        OnNewNB?.Invoke(round.ToString());
    }

    private GameObject FindSpawnable(GameMode gm)
    {
        AchievableList.Shuffle();
        foreach (var item in AchievableList)
        {
            if (!item.isActive(gm))
            {
                if(item.objs.TryGetValue(gm,out GameObject go))
                {
                    return go;
                }
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


    public void StartGame(int mode)
    {
        Time.timeScale = 1f;
        Player.SetActive(true);
        switch (mode)
        {
            case 0:
                gameMode = GameMode.Normal;
                break;
            case 1:
                gameMode = GameMode.Elite;
                break;
            case 2:
                gameMode = GameMode.Cursed;
                break;
            default: break;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    


}
