using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public SO_Input soFrameInput;
    public SO_Action respawn;

    // Update is called once per frame
    void Update()
    {
        soFrameInput.frameInput = new FrameInput {
            Space_P = Input.GetButtonDown("Jump"),
            Space_R = Input.GetButtonUp("Jump"),
            HorisontalAxis = Input.GetAxisRaw("Horizontal")
        };
        if (Input.GetKeyDown(KeyCode.R)) respawn.OnTrigger?.Invoke();
    }
}
