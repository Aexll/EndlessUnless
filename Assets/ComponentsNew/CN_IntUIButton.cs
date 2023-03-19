using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CN_IntUIButton : MonoBehaviour
{
    public Button button;
    public int stateToGive;
    public intc intContainer;


    private void OnEnable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        intContainer.Value = stateToGive;
    }

}
