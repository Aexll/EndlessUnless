using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class C_AchBox : MonoBehaviour
{
    public int boxId = -1;
    public string achievementId;
    public SO_AchievementList _AchievementList;
    [SerializeField] private Image img;
    [SerializeField] private Image bg;
    [SerializeField] private Image bg_1;
    [SerializeField] private Image bg_2;
    [SerializeField] private Sprite lockedSprite;
    [SerializeField] private AspectRatioFitter ARF;
    [SerializeField] private RectTransform imgbox;

    [SerializeField] private TextMeshProUGUI txt_name;
    [SerializeField] private TextMeshProUGUI txt_desc;
    [SerializeField] private TMP_FontAsset censorFont;
    [SerializeField] private TMP_FontAsset normalFont;

    [SerializeField] private Button button;
    [SerializeField] private Animator animator;
    [SerializeField] private SO_Action OnSelect;

    public bool Selected
    {
        get {
            return animator.GetBool("Selected");
        }
        set {
            animator.SetBool("Selected", value);
        }
    }

    private void Awake()
    {

        // select / unselect myself
        button.onClick.AddListener(() => {

            if(Selected)
            {
                OnSelect.OnTrigger.Invoke();
            }
            else
            {
                OnSelect.OnTrigger.Invoke();
                Selected = true;
            }
        });

        // unselect all
        OnSelect.OnTrigger.AddListener(() =>
        {
            Selected = false;
        });

        // reaction upon new ach unlocked
        _AchievementList.OnNewAchievementUnlocked.AddListener((Achievement _ach) =>
        {
            if(achievementId == _ach.id)
                UpdateAchievement();
        });
        //reaction upon updatin statue of an ach
        _AchievementList.OnUpdateAch.AddListener((string id) =>
        {
            if(id == "_all" || id == achievementId)
                UpdateAchievement();
        });




}

    public void UpdateAchievement()
    {
        SetAchievement(achievementId);
    }

    public void SetAchievement(string id)
    {
        achievementId = id;
        if(achievementId != null && _AchievementList != null) { 
            Achievement achievement = _AchievementList.GetAchievementById(achievementId);

            // select the sprite
            Sprite toShowSprite = achievement.img;
            if(!achievement.isUnlocked)
            { // if not unlocked, dont show the image
                toShowSprite = lockedSprite;
            }

            // image
            var aspectRatio = toShowSprite.textureRect.width / toShowSprite.texture.height;
            img.sprite = toShowSprite;
            ARF.aspectRatio = aspectRatio;
            //imgbox.sizeDelta = new Vector2(achievement.size * 80, achievement.size * 80);

            // bg
            bg.sprite = achievement.bg;
            bg_1.sprite = achievement.bg;
            bg_2.sprite = achievement.bg;

            // bg color
            bg.color = achievement.color;
            bg_1.color = achievement.color;
            //bg_2.color = achievement.color;

            // textes
            txt_name.text = achievement.name;
            txt_desc.text = achievement.description;


            // fonts
            txt_name.font = normalFont;
            txt_desc.font = normalFont;
            if (!achievement.isUnlocked)
            { // if locked dont show the name neither
                txt_name.font = censorFont;
                if (achievement.isDescriptionLocked)
                {
                    txt_desc.font = censorFont;
                }
            }
        }
    }

}
