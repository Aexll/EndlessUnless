using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SimpleSpawn : MonoBehaviour
{
    public bool spawnOnPlay;
    public GameObject spawnPrefab;
    public Vector3 spawnPosition;
    public float spawnAngle;
    public Vector3 spawnSize;
    [Tooltip("leave empty if no parent (sad)")]
    public Transform parent;
    public bool absolutPosition;
    public bool absolutRotation;

    private GameObject newlySpawned;


    private void Start()
    {
        if (spawnOnPlay)
            Spawn();
    }


    public void Spawn()
    {

        Vector3 finalPosition = spawnPosition;
        if(!absolutPosition)
        {
            finalPosition += parent.position;
        }

        Quaternion finalRotation = Quaternion.AngleAxis(spawnAngle, Vector3.forward);
        if (!absolutRotation)
        {
            finalRotation *= parent.rotation;
        }


        if(parent != null)
            newlySpawned = Instantiate(spawnPrefab, finalPosition,finalRotation, parent);
        else
            newlySpawned = Instantiate(spawnPrefab, finalPosition,finalRotation);
        
        newlySpawned.transform.localScale = spawnSize;
    }

    public void Spawn(Vector3 position)
    {
        if(parent != null)
            newlySpawned = Instantiate(spawnPrefab,position,Quaternion.identity,parent);
        else
            newlySpawned = Instantiate(spawnPrefab,position,Quaternion.identity);
        
        newlySpawned.transform.localScale = spawnSize;
    
    }

    public void SetPosition(Vector3 position)
    {
        spawnPosition = position;
    }

    public void SetAngle(float angle)
    {
        spawnAngle = angle;
    }

    public void SetPrefab(GameObject prefab)
    {
        spawnPrefab = prefab;
    }
}
