using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CN_BoolEventSwitch : MonoBehaviour
{
    public UnityEvent OnSelected;
    public UnityEvent OnUnselected;
    public boolc boolContainer;

    private void Awake()
    {
        boolContainer.OnChange += (bool newbool) =>
        {
            if(newbool)
            {
                OnSelected.Invoke();
            }
            else
            {
                OnUnselected.Invoke();
            }
        };
    }
}
