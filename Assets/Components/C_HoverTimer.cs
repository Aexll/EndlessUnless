using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class C_HoverTimer : MonoBehaviour, IResetable
{
    public float timerSpeed = 1f; // How fast the timer should increase/decrease
    private float hoverTime = 0f; // How long the mouse has been hovering over the object
    private bool isHovering = false; // Whether the mouse is currently hovering over the object
    public UnityEvent<float> WhileTimer;
    public UnityEvent OnReachZero;
    public UnityEvent OnReachOne;


    void OnMouseOver()
    {
        isHovering = true;
    }

    void OnMouseExit()
    {
        isHovering = false;
    }

    IEnumerator HoverTimerCoroutine()
    {
        while (true)
        {
            if (isHovering)
            {
                hoverTime = Mathf.Clamp01(hoverTime + Time.deltaTime * timerSpeed); // Increase the timer
                if (hoverTime >= 1) OnReachOne?.Invoke();
            }
            else
            {
                hoverTime = Mathf.Clamp01(hoverTime - Time.deltaTime * timerSpeed); // Decrease the timer
                if (hoverTime <= 0) OnReachZero?.Invoke();
            }

            WhileTimer?.Invoke(hoverTime);

            yield return null;
        }
    }


    private void OnEnable()
    {
        StartCoroutine(HoverTimerCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Reseting()
    {
        hoverTime = 0f;
        isHovering = false;
    }
}
