using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

public class C_EventReciver : MonoBehaviour
{

    [SerializeField] private string onlyListenTo;

    public UnityEvent OnTrigger;

    private string[] tags;

    // test si deux arrays de string contienne un ellement en commun
    bool ArraysContainCommonElement(string[] array1, string[] array2) => array1.Intersect(array2).Any();

    private void Awake()
    {
        tags = Regex.Split(onlyListenTo, "([^|]+)+");
    }

    public void Recive(string eventString)
    {
        string[] recivingTags = Regex.Split(eventString, "(|[^|]+)+");

        if(ArraysContainCommonElement(tags,recivingTags))
        {
            OnTrigger?.Invoke();
        }
    }
}
