using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    public intc intcont;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Ship/My Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        GetWindow(typeof(MyWindow));
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        myString = EditorGUILayout.TextField("Text Field", myString);

        intcont = EditorGUILayout.ObjectField("", intcont, typeof(intc), true) as intc;

        if (GUILayout.Button("Test"))
        {
            //intc container = AssetCreator.Create<int, intc>("lol",null);
            //intcont = container;
        }

        //groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        //myBool = EditorGUILayout.Toggle("Toggle", myBool);
        //myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        //EditorGUILayout.EndToggleGroup();


    }
}