using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CN_Blaster : MonoBehaviour
{
    public Vector3c targetPosition;
    public intc state;
    public Sprite imgNormal;
    public Sprite imgCharge;
    public Sprite imgShout;

    private void OnEnable()
    {

        state.OnChange += (int value) => {
            switch (value)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        };


        StartCoroutine(StateCoroutine());
    }

    private IEnumerator StateCoroutine()
    {
        while (true)
        {
            state.Value = 0;
            yield return new WaitForSeconds(1f);
            state.Value = 1;
            yield return new WaitForSeconds(1f);
            state.Value = 2;
            yield return new WaitForSeconds(1f);
        }
    }
}
