using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(l2uparser))]
public class l2ueditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        l2uparser parser = (l2uparser)target;

        if (GUILayout.Button("OpenFile"))
        {
            parser.Spawn();
        }
    }
}
