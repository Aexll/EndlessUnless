using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CN_SurvivalSpawner : MonoBehaviour
{

    public MapManager mapManager;

    private void OnEnable()
    {
        Invoke(nameof(SpawnEntity), mapManager.survivalSpawnInterval);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void SpawnEntity()
    {
        mapManager.SpawnNewEntity();
        Invoke(nameof(SpawnEntity), mapManager.survivalSpawnInterval);
    }

}
