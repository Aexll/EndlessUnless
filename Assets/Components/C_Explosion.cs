using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_Explosion : MonoBehaviour
{

    [SerializeField] private float radius = 1;

    public UnityEvent<GameObject> OnExploded;


    public void Explode()
    {
        var overlaped = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var colliding in overlaped)
        {
            OnExploded?.Invoke(colliding.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
