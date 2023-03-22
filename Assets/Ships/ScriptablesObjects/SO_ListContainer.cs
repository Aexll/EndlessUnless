using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CLt_", menuName = "Containers/List template")]
public class SO_ListContainer<T> : ScriptableObject {

    public List<T> valuelist;

    public T Get(int index)
    {
        return valuelist[index];
    }

    public void Add(T newValue)
    {
        valuelist.Add(newValue);
    }


}
