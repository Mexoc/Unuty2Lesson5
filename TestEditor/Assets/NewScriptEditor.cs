using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(NewScript))]
public class NewScriptEditor : Editor
{
    bool _isPressed;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        NewScript test = (NewScript)target;

        var isPressed = GUILayout.Button("Создание объектов", EditorStyles.miniButton);

        if (isPressed)
        {
            EditorGUILayout.HelpBox("Click", MessageType.Warning);
        }
    }
}
