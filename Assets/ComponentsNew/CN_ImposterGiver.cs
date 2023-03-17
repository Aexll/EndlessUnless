using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CN_ImposterGiver : MonoBehaviour, IResetable
{
    public intc imposterId;

    public void Reseting()
    {
        imposterId.Value = Random.Range(0, 5);
    }
}
