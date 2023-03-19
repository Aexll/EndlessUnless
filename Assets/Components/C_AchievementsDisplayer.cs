using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AudioSettings;

public class C_AchievementsDisplayer : MonoBehaviour
{

    [SerializeField] GameObject boxPrefab;
    [SerializeField] Transform panel;
    [SerializeField] SO_AchievementList _AchievementList;
    
    private List<C_AchBox> spawnedBoxes = new List<C_AchBox>();

    void Start()
    {
        foreach (var item in _AchievementList.allAchievements)
        {
            var newBox = Instantiate(boxPrefab,panel);
            var cmp = newBox.GetComponent<C_AchBox>();
            if (cmp != null)
            {
                cmp.boxId = spawnedBoxes.Count;
                spawnedBoxes.Add(cmp);
                cmp.SetAchievement(item.id);
            }
        }
    }
}
