using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_SkinButton : MonoBehaviour
{
    public Sprite sprite;
    public Image image;
    public Button button;
    private SpriteRenderer spriteRendererPlayer;

    private void Awake()
    {
        button.onClick.AddListener(ApplySkinToPlayer);
        image.sprite = sprite;
        var player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            spriteRendererPlayer = player.GetComponent<SpriteRenderer>();
        }
    }

    public void UpdateSprite(Sprite newSprite)
    {
        sprite = newSprite;
        image.sprite = sprite;
    }

    public void ApplySkinToPlayer()
    {
        spriteRendererPlayer.sprite = sprite;
    }
}
