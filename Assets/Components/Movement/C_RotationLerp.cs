using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RotationLerp : MonoBehaviour, IResetable
{

    public bool autoStart = false;
    public AnimationCurve rotCurve;
    public Vector3 initialRotation;
    public Vector3 finalRotation;
    public float duration = 1f;
    public bool endOnMax = false;
    public Transform parent;


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
            float curveValue = rotCurve.Evaluate(t / duration);
            Vector3 newScale = Vector3.Lerp(initialRotation, finalRotation, curveValue);
            transform.rotation = parent.rotation * Quaternion.Euler(newScale);

            t += Time.deltaTime;
            yield return null;
        }

        //transform.localScale = initialScale;
        if(endOnMax)
            transform.rotation = parent.rotation * Quaternion.Euler(finalRotation);
        else
            transform.rotation = parent.rotation * Quaternion.Euler(initialRotation);

    }

    public void Reseting()
    {
        StopAllCoroutines();
        /*if(endOnMax)
            transform.localScale = maxScale;
        else*/
        transform.rotation = parent.rotation * Quaternion.Euler(initialRotation);
    }
}
