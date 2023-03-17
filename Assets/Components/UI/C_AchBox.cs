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
    [SerializeField] private List<Sprite> bg_normal;
    [SerializeField] private List<Sprite> bg_elite;
    [SerializeField] private List<Sprite> bg_cursed;
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
            /*
            bg.sprite = bg_normal;
            bg_1.sprite = bg_normal;
            bg_2.sprite = bg_normal;
            */

            List<Sprite> temp_chosenList;

            switch (achievement.gameMode)
            {
                case GameMode.Normal:
                    temp_chosenList = bg_normal;
                    break;
                case GameMode.Elite:
                    temp_chosenList = bg_elite;
                    break;
                case GameMode.Cursed:
                    temp_chosenList = bg_cursed;
                    break;
                default:
                    temp_chosenList = new List<Sprite>();
                    break;
            }

            int nb = Mathf.Clamp(achievement.maxRound / temp_chosenList.Count, 0, temp_chosenList.Count -1);
            bg.sprite = temp_chosenList[nb];




            if(achievement.isUnlocked)
                txt_name.color = achievement.color;


            // bg color
            if (!achievement.isUnlocked)
            {
                bg.color = new Color(0.2f, 0.2f, 0.2f, 1);
                bg_1.color = new Color(0.2f, 0.2f, 0.2f, 1);
            }
            else
            {
                bg.color = Color.white;
                bg_1.color = Color.white;
            }
            //bg.color = achievement.color;
            //bg_1.color = achievement.color;
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
