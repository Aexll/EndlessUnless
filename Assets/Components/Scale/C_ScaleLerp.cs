using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ScaleLerp : MonoBehaviour, IResetable
{
    public AnimationCurve scaleCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);
    public float duration = 1f;
    public bool loop = false;

    private Vector3 startScale;
    private float startTime;
    private bool isRunning = false;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        if (isRunning)
        {
            float timeElapsed = Time.time - startTime;
            float normalizedTime = Mathf.Clamp01(timeElapsed / duration);
            float scale = scaleCurve.Evaluate(normalizedTime);
            transform.localScale = startScale * scale;

            if (timeElapsed >= duration)
            {
                if (loop)
                {
                    startTime = Time.time;
                }
                else
                {
                    isRunning = false;
                }
            }
        }
    }

    public void Run()
    {
        isRunning = true;
        startTime = Time.time;
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void Reseting()
    {
        transform.localScale = startScale;
    }
    /*
public Transform toScale;
public AnimationCurve crv;
public Vector3 start_scale;
public Vector3 end_scale;
public float timeScale;

public float time = 0;

private Coroutine coroutine;

public void Run()
{
   StopAllCoroutines();
   StartCoroutine(Running());
}

public void Stop()
{
   StopAllCoroutines();
}

private IEnumerator Running()
{

   while (time <= 1)
   {
       toScale.localScale = Vector3.Lerp(start_scale, end_scale, crv.);
       yield return null;
       time += Time.deltaTime * timeScale;
   }
}
*/
}
