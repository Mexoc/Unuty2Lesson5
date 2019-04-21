using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;

public class NewEditor : MonoBehaviour
{
    public int count = 42;
    public int step = 2;

    private void Start()
    {


#if UNITY_EDITOR
        for (int i = 0; i < count; i++)
        {
            EditorUtility.DisplayProgressBar("Загрузка", $"% {i}", i / count);
            Thread.Sleep(step*100);
        }

        EditorUtility.ClearProgressBar();
#endif
    }
}
