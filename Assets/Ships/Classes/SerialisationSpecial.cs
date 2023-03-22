using JetBrains.Annotations;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(intcc))]
public class ContainerDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;



        SerializedProperty valueLocal = property.FindPropertyRelative("valueLocal");
        SerializedProperty valueContainer = property.FindPropertyRelative("valueContainer");
        
        
        
        object obj = null;
        if (valueContainer != null)
            obj = valueContainer.objectReferenceValue;



        Rect amountRect;
        Rect unitRect;
        Rect btnRect;
        
        // value | so | btn
        if(obj == null)
        {

            // Calculate rects
            amountRect = new Rect(position.x, position.y, position.size.x * 0.8f - 20, position.height);
            unitRect = new Rect(position.x + position.size.x * 0.8f - 20, position.y,20, position.height);

        }
        else
        {

            // Calculate rects
            amountRect = new Rect(position.x, position.y, position.size.x / 8, position.height);
            unitRect = new Rect(position.x, position.y,position.size.x * .8f, position.height);

        }


        btnRect = new Rect(position.x + position.size.x * .8f, position.y, position.size.x - position.size.x * .8f - 5, position.height);


        // Draw fields - pass GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("valueLocal"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("valueContainer"), GUIContent.none);

        string prefix = "Ci_";


        if (GUI.Button(btnRect, "new"))
        {
            intc newSO = AssetCreator.Create<int,intc>(prefix + CustomFunction.ToCamelCase(label.text));
            
            //if(newSO != null) { valueContainer.objectReferenceValue = newSO; }

            GUIUtility.ExitGUI();
        }
        EditorGUI.indentLevel = 0;


        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}


public static class AssetCreator
{
    public static SO Create<C,SO>(string assetName) where SO : SO_ValueContainer<C>
    {
        Debug.Log("Hello world !");
        string absPath = EditorUtility.OpenFolderPanel("Select a folder", "Assets/Ships/Created", "");
        if(absPath.Length != 0)
        {
            string relativePath = absPath.Substring(absPath.IndexOf("Assets/"));
            SO newSO = ScriptableObject.CreateInstance<SO>();
            AssetDatabase.CreateAsset(newSO, relativePath + "/" + assetName + ".asset");
            return newSO;
            //AssetDatabase.SaveAssets();
        }
        return null;
    }
}
