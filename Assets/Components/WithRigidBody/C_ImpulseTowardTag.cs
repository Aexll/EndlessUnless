using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ImpulseTowardTag : MonoBehaviour
{

    public bool autoStart = true;
    [SerializeField] private float impulseForce = 10f;
    public string targetTag;
    private Transform target;
    private Transform Target
    {
        get {
            if (target == null)
            {
                var go = GameObject.FindGameObjectWithTag(targetTag);
                if(go != null)
                {
                    target = go.transform;
                }
            }
            return target;
        }
    }


    private Rigidbody2D rb;
    public Vector2 ImpulseOffset = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if(autoStart) Impulse();
    }

    public void Impulse()
    {
        if (Target != null)
        {
            Vector2 direction = Target.position - transform.position;
            direction.Normalize();
            rb.AddForce(direction * impulseForce + ImpulseOffset, ForceMode2D.Impulse);
        }
    }

}
