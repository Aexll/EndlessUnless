using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class C_BoxTrigger : MonoBehaviour
{
    [SerializeField] private List<string> TagsWhitelist;

    public UnityEvent<GameObject> OnEnter;
    public UnityEvent<GameObject> OnLeave;
    public UnityEvent<GameObject> WhileStay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TagsWhitelist.Contains(collision.tag))
        OnEnter?.Invoke(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnLeave?.Invoke(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        WhileStay?.Invoke(collision.gameObject);
    }
}
