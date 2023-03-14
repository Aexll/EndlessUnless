using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputEvent : MonoBehaviour
{

    public SO_Input input;
    public UnityEvent OnJump;

    private void Update()
    {
        if (input.frameInput.Space_P)
        {
            OnJump.Invoke();
        }
    }

}
