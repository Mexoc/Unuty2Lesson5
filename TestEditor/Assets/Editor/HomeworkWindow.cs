using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HomeworkWindow : EditorWindow
{
    public GameObject _instanceObject1;
    public GameObject _instanceObject2;
    private bool randomColor;
    private int countObjects;
    private bool groupEnable;
    private bool objectType1;
    private bool objectType2;
    private float y = 0;
    private string objectName;
    private int nameCount = 1;
    private List<GameObject> objectsOnScene = new List<GameObject>();


    Color[] colors = new Color[]
    {
        Color.black, Color.red, Color.yellow, Color.blue, Color.cyan, Color.magenta
    };

    [MenuItem ("Geekbrains/HomeworkWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(HomeworkWindow));
    }

    private void Awake()
    {
       
    }

    private void OnGUI()
    {
        GUILayout.Label("Настройки", EditorStyles.boldLabel);
        _instanceObject1 = EditorGUILayout.ObjectField("Объект первого типа", _instanceObject1, typeof(GameObject), true) as GameObject;
        _instanceObject2 = EditorGUILayout.ObjectField("Объект второго типа", _instanceObject2, typeof(GameObject), true) as GameObject;

        groupEnable = EditorGUILayout.BeginToggleGroup("Свойства", groupEnable);
        objectType1 = EditorGUILayout.Toggle("Создать объекты первого типа", objectType1);
        objectType2 = EditorGUILayout.Toggle("Создать объекты второго типа", objectType2);
        randomColor = EditorGUILayout.Toggle("Случайный цвет", randomColor);
        countObjects = EditorGUILayout.IntSlider("Количество объектов", countObjects, 1, 10);
        EditorGUILayout.EndToggleGroup();

        //создание объектов вдоль оси X
        if (GUILayout.Button("Создать объекты"))
        {
            for (float i = 0; i <= countObjects; i++)
            {                                
                //если объекты не заданы из префабов - будут заданы автоматически
                if (_instanceObject1 == null && _instanceObject2 == null)
                {
                    _instanceObject1 = Instantiate(Resources.Load("guy")) as GameObject;
                    _instanceObject1.name = "Object" + nameCount;
                    nameCount++;
                    _instanceObject2 = Instantiate(Resources.Load("armedGuy")) as GameObject;
                    _instanceObject2.name = "Object" + nameCount;
                    nameCount++;
                }
                //создание объектов только первого префаба
                if (objectType1 && !objectType2)
                {
                    if (_instanceObject1 != null)
                    {                        
                        Instantiate(_instanceObject1, new Vector3(i, y, 0), Quaternion.identity);
                        _instanceObject1.name = "Object" + nameCount;
                        nameCount++;
                    }                        
                }
                //создание объектов только второго префаба
                else if (objectType2 && !objectType1)
                {
                    if (_instanceObject2 != null)
                    {                        
                        Instantiate(_instanceObject2, new Vector3(i, y, 0), Quaternion.identity);
                        _instanceObject2.name = "Object" + nameCount;
                        nameCount++;
                    }                        
                }
                //создание объектов обоих префабов с чередованием в зависимости от чётности счётчика
                if (objectType1 && objectType2)
                {
                    if (i % 2 != 0)
                    {                        
                        Instantiate(_instanceObject1, new Vector3(i, y, 0), Quaternion.identity);
                        _instanceObject1.name = "Object" + nameCount;
                        nameCount++;
                    }
                    else
                    {                        
                        Instantiate(_instanceObject2, new Vector3(i, y, 0), Quaternion.identity);
                        _instanceObject2.name = "Object" + nameCount;
                        nameCount++;
                    }                      
                }
                if (randomColor && _instanceObject1.GetComponent<Renderer>())
                {
                    _instanceObject1.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];                    
                }
                if (randomColor && _instanceObject2.GetComponent<Renderer>())
                {
                    _instanceObject2.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                }
            }
            y += 1f;
        }
        
        if (GUILayout.Button("Удалить объекты"))
        {            
            GameObject[] temp1;
            GameObject[] temp2;
            temp1 = GameObject.FindGameObjectsWithTag("objectType1");
            temp2 = GameObject.FindGameObjectsWithTag("objectType2");
            foreach (var obj in temp1)
            {
                Destroy(obj);
            }
            foreach (var obj in temp2)
            {
                Destroy(obj);
            }
            nameCount = 1;
        }

    }
}

