using JetBrains.Annotations;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(intcc))]
public class IngredientDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var pp = property.FindPropertyRelative("valueContainer");
        var obj = pp.objectReferenceValue;



        Rect amountRect;
        Rect unitRect;
        Rect btnRect;
        
        // value | so | btn
        if(obj == null)
        {

            // Calculate rects
            amountRect = new Rect(position.x, position.y, position.size.x / 2, position.height);
            unitRect = new Rect(position.x + position.size.x/2, position.y,20, position.height);

        }
        else
        {

            // Calculate rects
            amountRect = new Rect(position.x, position.y, position.size.x / 8, position.height);
            unitRect = new Rect(position.x, position.y,position.size.x * .625f, position.height);

        }


        btnRect = new Rect(position.x + position.size.x * .625f, position.y, position.size.x - position.size.x * .625f - 5, position.height);


        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("valueLocal"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("valueContainer"), GUIContent.none);


        if (EditorGUI.LinkButton(btnRect, "test"))
        {
            Debug.Log("Hello");
        }
        EditorGUI.indentLevel = 0;


        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}


public static class AssetCreator
{
    public static void Create()
    {
        Debug.Log("Hello world !");
        intc newSO = ScriptableObject.CreateInstance<intc>();
        AssetDatabase.CreateAsset(newSO, "Assets/Ships/test.asset");
        AssetDatabase.SaveAssets();
    }
}