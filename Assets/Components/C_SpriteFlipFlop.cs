using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SpriteFlipFlop : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public float time = 0.5f;
    public bool flipX = false;
    public bool flipY = false;

    private void Awake()
    {
        if (spriteRenderer == null) spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private IEnumerator Start()
    {
        while (true)
        {
            if(flipX) spriteRenderer.flipX = !spriteRenderer.flipX;
            if(flipY) spriteRenderer.flipY = !spriteRenderer.flipY;
            yield return new WaitForSeconds(time);
        }
    }
}
