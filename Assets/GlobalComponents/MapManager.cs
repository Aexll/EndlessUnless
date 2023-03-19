using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [SerializeField] private GameObject LoseMenu;


    // list of all objects on the map with the achievable script
    private List<C_Achievable> AchievableList;

    //public UnityEvent<string> OnNewNB;


    // game options
    //private GameMode gameMode = GameMode.Normal;
    //private bool NoHitEnabled = false;
    //private bool SurvivalEnabled = false;

    // game options
    public intc intGameMode;
    public boolc bNoHit;
    public boolc bSurvival;

    // game info
    public intc EntityOnScreen;
    public floatc InGameTime;
    public intc PlayerDeaths;

    // game events
    public SO_Action PlayerRespawn;


    // wrapper for the gamemode
    public GameMode gameMode
    {
        get { return (GameMode)intGameMode.Value; }
    }


    private void Awake()
    {
        AchievableList = AxelUtils.FindObjectsImplementingInterface<C_Achievable>(false);
        PlayerRespawn.OnTrigger.AddListener(OnPlayerRespawn);
    }

    private void Start()
    {
        ResetAllStates();
    }

    public void OnPlayerWin()
    {
        int nb = 0;
        // unlock new achievements
        if (AchievableList != null)
        {   
            // count of the enity on the map
            foreach (var item in AchievableList)
            {
                if(item.isActive(gameMode))
                {
                    nb++;
                }
            }

            EntityOnScreen.Value = nb;

            // unlock locked achievments
            foreach (var item in AchievableList)
            {
                if(item.isActive(gameMode))
                {
                    string finalId = item.achievementId;
                    if (gameMode == GameMode.Elite) finalId += "(e)";
                    else if (gameMode == GameMode.Cursed) finalId += "(c)";
                    //print(finalId);
                    _AchievementList.UnlockAchievement(finalId, EntityOnScreen.Value);
                }
            }
        }
        else
        {
            EntityOnScreen.Value = 0;
        }


        // spawn a new object
        var obj = FindSpawnable(gameMode);
        if(obj != null)
        {
            obj.SetActive(true);
        }

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

    // remove all the objects spawned on the map
    public void CleanAllSpawned()
    {
        foreach (var item in AchievableList)
        {
            if(item.objToActivate != null)
                item.objToActivate.SetActive(false);
            if(item.objToActivateElite != null)
                item.objToActivateElite.SetActive(false);
        }

    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        Player.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Player.SetActive(false);
    }

    public void OnPlayerRespawn()
    {
        PlayerDeaths.Value++;

        print("Player dead");
        if(bNoHit.Value || bSurvival.Value)
        {
            PauseGame();
            CleanAllSpawned();
            LoseMenu.SetActive(true);
        }
    }

    public void ResetAllStates()
    {
        CleanAllSpawned();
        Player.SetActive(false);
        InGameTime.Value = 0;
        EntityOnScreen.Value = 0;
        intGameMode.Value = 0;
        bNoHit.Value = false;
        bSurvival.Value = false;
        PauseGame();
    }
}
