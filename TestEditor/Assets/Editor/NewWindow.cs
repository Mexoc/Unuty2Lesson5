using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class NewWindow : EditorWindow
{
    public GameObject objectInstance;
    public string name = "Object";
    bool groupEnable;
    bool randomColor;
    int countObject;
    float radius;
    Color[] color = new Color[]
    {
        Color.red, Color.gray, Color.green, Color.yellow, Color.blue
    };

    [MenuItem ("Geekbrains/MyWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(NewWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
        objectInstance = EditorGUILayout.ObjectField("Объект", objectInstance, typeof(GameObject), true) as GameObject;
        name = EditorGUILayout.TextField("имя", name);
        groupEnable = EditorGUILayout.BeginToggleGroup("Дополнительные еастройки", groupEnable);

        randomColor = EditorGUILayout.Toggle("рандомный цвет", randomColor);
        radius = EditorGUILayout.Slider("Радиус", countObject, 8, 20);
        countObject = EditorGUILayout.IntSlider("Количество объектов", countObject, 8, 20);

        EditorGUILayout.EndToggleGroup();

        if (GUILayout.Button("Создать объекты"))
        {
            GameObject root = new GameObject("Root");
            for (int i= 0; i < countObject; i++)
            {
                float angle = i * Mathf.PI * 6 / countObject;
                Vector3 pos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
                GameObject temp = Instantiate(objectInstance, pos, Quaternion.identity) as GameObject;
                temp.name = name + " (" + i + ")";
                temp.transform.parent = root.transform;
                if (randomColor && temp.GetComponent<Renderer>())
                {
                    temp.GetComponent<Renderer>().material.color = color[Random.Range(0,color.Length)];
                }
            }
        }
    }
}
