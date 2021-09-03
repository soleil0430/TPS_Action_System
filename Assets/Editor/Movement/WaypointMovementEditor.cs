using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Movement;

[CustomEditor(typeof(WaypointMovement))]
public class WaypointMovementEditor : Editor
{
    WaypointMovement obj;


    private void OnEnable()
    {
        obj = target as WaypointMovement;
    }

    public override void OnInspectorGUI()
    {
        SerializedProperty wayPoints = serializedObject.FindProperty("wayPoints");
        EditorGUILayout.PropertyField(wayPoints, true);
        serializedObject.ApplyModifiedProperties();

        obj.speed = EditorGUILayout.FloatField("Speed", obj.speed);


        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.IntField("Now Way Point", obj.nowWayPointIndex);
        EditorGUILayout.Vector3Field("Direction", obj.direction);
        EditorGUI.EndDisabledGroup();

    }


}
