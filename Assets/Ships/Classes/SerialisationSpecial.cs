using JetBrains.Annotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

public static class LastFolderSelected
{

    public static string LastPath = "Assets";
}


// main class
public class ContainerDrawer<C,SO,T> : PropertyDrawer where SO : SO_ValueContainer<C> where T : ValueContainerClass<C,SO>
{
    private const string ValueLocalPropertyName = "valueLocal";
    private const string ValueContainerPropertyName = "valueContainer";
    private string ContainerNamePrefix = "C" + typeof(C).Name[0].ToString().ToLower() +"_";
    private string ContainerNameSufix = ""; // "_" + typeof(C).Name ;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Begin property
        EditorGUI.BeginProperty(position, label, property);

        // Remove indentation
        var previousIndentationLevel = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;


        // Get value local and value container properties
        var valueLocalProperty = property.FindPropertyRelative(ValueLocalPropertyName);
        var valueContainerProperty = property.FindPropertyRelative(ValueContainerPropertyName);
        
        Rect amountRect;
        Rect unitRect;
        Rect btnRect;
        
        object obj = valueContainerProperty?.objectReferenceValue;

        if (obj == null) // when container aviable
        {
            amountRect = new Rect(position.x, position.y, position.size.x * 0.9f - 20, position.height);
            unitRect = new Rect(position.x + position.size.x - 40, position.y,20, position.height);
        }
        else
        {
            amountRect = new Rect(position.x, position.y, position.size.x / 8, position.height);
            unitRect = new Rect(position.x, position.y,position.size.x - 40, position.height);
        }
        btnRect = new Rect(position.x + position.size.x - 20, position.y, 20/*position.size.x - position.size.x*/ , position.height);


        // Draw amount and unit fields
        EditorGUI.PropertyField(amountRect, valueLocalProperty, GUIContent.none);
        EditorGUI.PropertyField(unitRect, valueContainerProperty, GUIContent.none);

        if (GUI.Button(btnRect, "+"))
        {
            //SO newSO = AssetCreator.Create<C,SO>(prefix + CustomFunction.ToCamelCase(label.text), valueContainerProperty);
            string assetName = ContainerNamePrefix + CustomFunction.ToCamelCase(label.text) + ContainerNameSufix;
            //string absPath = "Assets/Ships/Created";
            string soPath = EditorUtility.SaveFilePanelInProject("Creating a new Container", assetName, "asset", "Chose a name", LastFolderSelected.LastPath);

            // If the user selected a folder, create a new instance of the scriptable object and save it to the selected folder
            if (!string.IsNullOrEmpty(soPath))
            {
                // save last path
                LastFolderSelected.LastPath = soPath;

                // Create a new instance of the scriptable object
                SO newScriptableObject = ScriptableObject.CreateInstance<SO>();
                AssetDatabase.CreateAsset(newScriptableObject, soPath);
                AssetDatabase.SaveAssets();
                EditorUtility.FocusProjectWindow();
                // Set the value of the property field with the new scriptable object
                valueContainerProperty.objectReferenceValue = newScriptableObject;
                //if(newSO != null) { valueContainer.objectReferenceValue = newSO; }
            }
            GUIUtility.ExitGUI();
        }
        EditorGUI.indentLevel = 0;


        // Set indent back to what it was
        EditorGUI.indentLevel = previousIndentationLevel;

        EditorGUI.EndProperty();
    }
}



[CustomPropertyDrawer(typeof(intcc))]
public class IntCPD : ContainerDrawer<int, intc, intcc> { };

[CustomPropertyDrawer(typeof(boolcc))]
public class BoolCPD : ContainerDrawer<bool, boolc, boolcc> { };

[CustomPropertyDrawer(typeof(stringcc))]
public class StringCPD : ContainerDrawer<string, stringc, stringcc> { };

[CustomPropertyDrawer(typeof(floatcc))]
public class FloatCPD : ContainerDrawer<float, floatc, floatcc> { };




//[CustomEditor(typeof(S_Test))]
public class folderSelectionInspector : Editor
{
    public override void OnInspectorGUI()
    {

        //GUILayout.

        GUILayout.BeginHorizontal();

        GUILayout.Label(target.name);
        //GUILayout.TextField(target.name);

        if(GUILayout.Button("Select folder"))
        {
            var path =EditorUtility.SaveFolderPanel("Create New Folder",LastFolderSelected.LastPath,target.name);
            LastFolderSelected.LastPath = path;
        }

        GUILayout.EndHorizontal();

        DrawDefaultInspector();
    }
}