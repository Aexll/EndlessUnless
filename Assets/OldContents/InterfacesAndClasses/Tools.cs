using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Get all component on the scene that implement an interface
/// </summary>
public static class AxelUtils
{
    public static List<T> FindObjectsImplementingInterface<T>(bool findInactives = false) where T : class
    {
        List<T> result = new List<T>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Resetable");
        foreach (var obj in objects)
        {
            Component[] components = obj.GetComponentsInChildren(typeof(T),findInactives);
            if (components != null)
            {
                foreach (var item in components)
                {
                    result.Add(item as T);
                }
                //result.AddRange(components);
            }
            else Debug.Log("error unvalid list");
        }
        return result;
    }



    // randomize a list (idk why its not by default but, ok...)

    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}