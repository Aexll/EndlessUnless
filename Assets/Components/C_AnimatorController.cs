using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AnimatorController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        if (animator == null) animator = gameObject.GetComponent<Animator>();
    }


    public void BoolToTrue(string boolname)
    {
        animator.SetBool(boolname, true);
    }

    public void BoolToFalse(string boolname)
    {
        animator.SetBool(boolname, false);
    }
}
