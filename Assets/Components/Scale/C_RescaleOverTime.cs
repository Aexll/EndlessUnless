using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class C_RescaleOverTime : MonoBehaviour, IResetable
{

    public bool autoStart = false;
    public AnimationCurve scaleCurve;
    public Vector3 initialScale;
    public Vector3 maxScale;
    public float duration = 1f;
    public bool endOnMax = false;


    private void Start()
    {
        //initialScale = transform.localScale;
        if (autoStart)
            StartRescaling();
    }

    public void StartRescaling()
    {
        StartCoroutine(RescaleCoroutine());
    }

    private IEnumerator RescaleCoroutine()
    {
        float t = 0f;
        while (t < duration)
        {
            float curveValue = scaleCurve.Evaluate(t / duration);
            Vector3 newScale = Vector3.Lerp(initialScale, maxScale, curveValue);
            transform.localScale = newScale;

            t += Time.deltaTime;
            yield return null;
        }

        //transform.localScale = initialScale;
        if(endOnMax)
            transform.localScale = maxScale;
        else
            transform.localScale = initialScale;

    }

    public void Reseting()
    {
        StopAllCoroutines();
        /*if(endOnMax)
            transform.localScale = maxScale;
        else*/
        transform.localScale = initialScale;
    }
}