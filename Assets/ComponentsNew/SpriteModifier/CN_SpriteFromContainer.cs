using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CN_SpriteFromContainer : MonoBehaviour
{
    public SpriteRenderer sr;
    public Spritec spriteContainer;

    public void Awake()
    {
        spriteContainer.OnChange += (Sprite _newSprite) =>
        {
            sr.sprite = _newSprite;
        };
    }

    private void OnEnable()
    {
        sr.sprite = spriteContainer.Value;
    }
}
