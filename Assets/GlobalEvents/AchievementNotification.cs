using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class AchievementNotification : MonoBehaviour
{

    public SO_AchievementList soAchievementsInstances;

    [SerializeField] private TextMeshProUGUI txt1;
    [SerializeField] private TextMeshProUGUI txt2;
    [SerializeField] private Image img;
    [SerializeField] private AspectRatioFitter ARF;
    [SerializeField] private RectTransform imgbox;
    [SerializeField] private Animator anim;

    private RectTransform txt1Rect;
    private RectTransform txt2Rect;
    //[SerializeField] private Sprite newimg;
    //[SerializeField] private float size = 1;

    private void Awake()
    {

        soAchievementsInstances.OnNewAchievementUnlocked.AddListener(ShowNewUnlockedAchievement);
        
        txt1Rect = txt1.GetComponent<RectTransform>();
        txt2Rect = txt2.GetComponent<RectTransform>();

        /*
        var txt1Rect = Text.GetComponent<RectTransform>();
        var txt2Rect = Description.GetComponent<RectTransform>();

        var aspectRatio =  newimg.texture.width / newimg.texture.height ;

        // set the sprite of img
        img.sprite= newimg;
        ARF.aspectRatio= aspectRatio;
        imgbox.sizeDelta = new Vector2(80*size, 80*size);
        //imgbox.rect.Set()
        //imgbox.rect.height= 80*size;
        
        if(txt1Rect != null && txt2Rect != null)
        {
            txt1Rect.anchoredPosition = new Vector3(imgbox.sizeDelta.x + 10,0);
            txt2Rect.anchoredPosition = new Vector3(imgbox.sizeDelta.y + 10,-26);

        }
        */
    }

    private void ShowNewUnlockedAchievement(Achievement achievement)
    {
        var aspectRatio = achievement.img.textureRect.width / achievement.img.texture.height;
        img.sprite = achievement.img;
        ARF.aspectRatio = aspectRatio;
        imgbox.sizeDelta = new Vector2(achievement.size * 80, achievement.size * 80);
        if(txt1Rect != null && txt2Rect != null)
        {
            txt1Rect.anchoredPosition = new Vector3(imgbox.sizeDelta.x + 10,0);
            txt2Rect.anchoredPosition = new Vector3(imgbox.sizeDelta.y + 10,-26);

        }

        // show the achievement name
        txt2.text= achievement.name;

        //anim.Play()
        //anim.Play("ach");
        anim.SetTrigger("Show");


    }
}





/*
class stateswitcher : MonoBehaviour
{

    public int state = 0;
    public List<UnityEvent> events;
    

    public void Trigger()
    {
        if (events.Count >= state)
        {
            events[state].Invoke();
        }
    }

    public void SetState(int i)
    {
        state = i;
    }

}
*/
