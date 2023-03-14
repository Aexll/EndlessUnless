using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Sound : MonoBehaviour, IResetable
{

    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if(audioSource == null)
            audioSource= GetComponent<AudioSource>();
    }

    public void Reseting()
    {
        audioSource.Stop();
        if(audioSource.playOnAwake)
        {
            audioSource.Play();
        }
    }

}
