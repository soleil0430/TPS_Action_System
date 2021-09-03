using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Movement;

[CustomEditor(typeof(DecidedMovement))]
public class DecidedMovementEditor : Editor
{
    DecidedMovement obj;


    private void OnEnable()
    {
        obj = target as DecidedMovement;
    }

    public override void OnInspectorGUI()
    {
        obj.moveCurve = EditorGUILayout.CurveField("Move Curve", obj.moveCurve);

        obj.startPosition = EditorGUILayout.Vector3Field("Start Position", obj.startPosition);
        obj.endPosition = EditorGUILayout.Vector3Field("End Position", obj.endPosition);

        obj.duration = EditorGUILayout.FloatField("Duration", obj.duration);

        EditorGUI.BeginDisabledGroup(true);
        obj.timer = EditorGUILayout.FloatField("Timer", obj.timer);
        EditorGUI.EndDisabledGroup();

    }

}
