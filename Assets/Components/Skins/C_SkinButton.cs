using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_SkinButton : MonoBehaviour
{
    public Sprite sprite;
    public Image image;
    public Button button;
    public Spritec PlayerSpriteContainer;
    //private SpriteRenderer spriteRendererPlayer;

    private void Awake()
    {
        button.onClick.AddListener(ApplySkinToPlayer);
        image.sprite = sprite;
    }

    public void UpdateSprite(Sprite newSprite)
    {
        sprite = newSprite;
        image.sprite = sprite;
    }

    public void ApplySkinToPlayer()
    {
        /*        
        if(spriteRendererPlayer != null)
        {
            SpritePlayer.sprite = sprite;
        }
        */
        PlayerSpriteContainer.Value = sprite;
    }
}
