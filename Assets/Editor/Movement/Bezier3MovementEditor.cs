using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Movement;

[CustomEditor(typeof(Bezier3Movement))]
public class Bezier3MovementEditor : Editor
{
    Bezier3Movement obj;


    private void OnEnable()
    {
        obj = target as Bezier3Movement;
    }

    public override void OnInspectorGUI()
    {
        SerializedProperty bezierPoints = serializedObject.FindProperty("bezierPoints");
        EditorGUILayout.PropertyField(bezierPoints, true);
        serializedObject.ApplyModifiedProperties();

        obj.duration = EditorGUILayout.FloatField("Duration", obj.duration);

        EditorGUI.BeginDisabledGroup(true);
        obj.timer = EditorGUILayout.FloatField("Timer", obj.timer);
        EditorGUI.EndDisabledGroup();
    }


}
