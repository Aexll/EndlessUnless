using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CN_Button : MonoBehaviour, IResetable
{
    public boolc isPressed;
    public Collider2D collid;
    public SpriteRenderer ButtonImage;
    public Sprite ButtonUp;
    public Sprite ButtonDown;

    private void OnEnable()
    {
        isPressed.OnChange += (bool _ispressed) =>
        {
            Sprite selectedSprite = _ispressed ? ButtonDown : ButtonUp;
            ButtonImage.sprite = selectedSprite;
        };
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPressed.Value)
        {
            isPressed.Value = true;
        }
    }

    public void Reseting()
    {
        isPressed.Value = false;
    }
}
