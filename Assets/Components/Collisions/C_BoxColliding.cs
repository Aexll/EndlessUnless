using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_BoxColliding : MonoBehaviour
{

    public UnityEvent<GameObject> OnCollisionEnter;
    public UnityEvent<GameObject> OnCollisionLeave;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEnter?.Invoke(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnCollisionLeave?.Invoke(collision.gameObject);
    }
}
