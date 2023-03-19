using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CN_TextFromInt : MonoBehaviour
{
    public TextMeshProUGUI TextToChange;
    public intc intContainer;

    private void Awake()
    {
        intContainer.OnChange += (int newInt) =>
        {
            TextToChange.text = newInt.ToString();
        };
    }
}
