using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CN_TextFromDifficulty : MonoBehaviour
{
    public TextMeshProUGUI TextToChange;
    public intc intContainer;

    private void Awake()
    {
        intContainer.OnChange += (int newInt) =>
        {
            TextToChange.text = ((GameMode)newInt).ToString();
        };
    }
    private void OnEnable()
    {
        TextToChange.text = ((GameMode)intContainer.Value).ToString();
    }


}
