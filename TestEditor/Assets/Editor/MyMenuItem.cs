using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyEditor
{
    public class MyMenuItem
    {        
        [MenuItem("Geekbrains/MenuItem1", false, 0)]
        public static void NewItem1()
        {
        }

        [MenuItem("Geekbrains/MenuItem2 %#a", false, 0)]
        public static void NewItem2()
        {
        }

        [MenuItem("Geekbrains/MenuItem3 &q", false, 0)]
        public static void NewItem3()
        {
        }

        [MenuItem("Geekbrains/MenuItem4 %q", false, 0)]
        public static void NewItem4()
        {
        }
    }
}  
