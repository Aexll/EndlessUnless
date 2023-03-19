using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CN_SpriteFromContainerUI : MonoBehaviour
{
    public Image image;
    public Spritec spriteContainer;

    public void Awake()
    {
        spriteContainer.OnChange += (Sprite _newSprite) =>
        {
            image.sprite = _newSprite;
        };
    }

    private void OnEnable()
    {
        image.sprite = spriteContainer.Value;
    }
}
