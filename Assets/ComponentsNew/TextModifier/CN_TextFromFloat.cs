using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CN_TextFromFloat : MonoBehaviour
{
    public TextMeshProUGUI TextToChange;
    public floatc intContainer;

    private void Awake()
    {
        intContainer.OnChange += (float newFloat) =>
        {
            TextToChange.text = newFloat.ToString("F2");
        };
    }

    private void OnEnable()
    {
        TextToChange.text = intContainer.Value.ToString("F2");
    }
}
