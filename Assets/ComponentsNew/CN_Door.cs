using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CN_Door : MonoBehaviour, IResetable
{
    public List<boolc> toWatch;
    public boolc isOpened;
    public GameObject door;


    private void OnEnable()
    {
        foreach (var item in toWatch)
        {
            item.OnChange += (bool value) =>
            {
                if (CanBeOpened())
                {
                    isOpened.Value = true;
                }
            };
        }

        isOpened.OnChange += (bool value) =>
        {
            door.SetActive(!value);
        };
    }

    public bool CanBeOpened()
    {
        bool b = true;
        foreach (var item in toWatch)
        {
            b &= item.Value;
        }
        return b;
    }

    public void Reseting()
    {
        isOpened.Value = false;
    }
}
