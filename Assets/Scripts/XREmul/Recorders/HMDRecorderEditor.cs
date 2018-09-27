using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HMDRecorder))]
public class HMDRecorderEditor : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var hmdRecorder = (HMDRecorder)target;

        if (GUILayout.Button("Save to File"))
        {
            var path = EditorUtility.SaveFilePanel("Save logs", "", "", ".csv");

            hmdRecorder.Dump(path);
        }
    }
}
