using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CN_Imposter : MonoBehaviour,IResetable
{
    public int selfId;
    public intc imposterId;
    public UnityEvent OnKilled;
    public UnityEvent OnKill;
    public bool isDead = false;

    public void Reseting()
    {
        isDead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead) { 
            if(collision.gameObject.tag == "Player")
            {
                if(imposterId.Value != selfId)
                {
                    OnKilled.Invoke();
                    isDead = true;
                }
                else
                {
                    OnKill.Invoke();
                }
            }
        }
    }
}
