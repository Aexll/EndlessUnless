using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SkinManager : MonoBehaviour
{
    public ListSpritec ListOfSkins;
    public GameObject skinbuttonPrefab;
    public RectTransform box;

    private void Awake()
    {
        foreach (var item in ListOfSkins.valuelist)
        {
            var obj = Instantiate(skinbuttonPrefab,box);
            var objSkinButtonScript = obj.GetComponent<C_SkinButton>();
            if(objSkinButtonScript != null )
            {
                objSkinButtonScript.UpdateSprite(item);
            }
        }
    }
}
