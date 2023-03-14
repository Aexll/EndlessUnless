using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Vector3 Scale = new Vector3(1,1,1);

    public void Spawn()
    {
        if (spawnTransform != null)
            Instantiate(prefab, spawnTransform);
        else
        {
            var spawned = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
            spawned.transform.localScale = Scale;
        }
    }

    public void SpawnAtTransformPosition(Transform tr)
    {
        Instantiate(prefab, tr.position, tr.rotation);
    }

    public void SetScale(Vector3 newScale)
    {
        Scale = newScale;
    }
}
