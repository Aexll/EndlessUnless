using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Impulse : MonoBehaviour, IResetable
{
    [SerializeField] private bool AutoStart;
    [SerializeField] private Vector2 force;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        if(AutoStart)
        {
            rb.AddForce(force);
        }
    }

    public void AddForce(Vector2 _force)
    {
        rb.AddForce(_force);
    }

    public void Impulse()
    {
        AddForce(force);
    }

    public void Reseting()
    {
        rb.velocity = Vector2.zero;
        if(AutoStart)
        {
            rb.AddForce(force);
        }
    }
}
