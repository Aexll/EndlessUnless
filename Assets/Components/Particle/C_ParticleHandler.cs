using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ParticleHandler : MonoBehaviour, IResetable
{


    [SerializeField] private ParticleSystem ps;

    private void Awake()
    {
        if(ps==null) ps = GetComponent<ParticleSystem>();
    }

    public void Reseting()
    {
        ps.Stop();
        ps.Clear();
        if(ps.main.playOnAwake)
        {
            ps.Play();
        }
    }

}
