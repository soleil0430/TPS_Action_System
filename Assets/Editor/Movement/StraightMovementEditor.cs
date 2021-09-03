using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Movement;

[CustomEditor(typeof(StraightMovement))]
public class StraightMovementEditor : Editor
{
    StraightMovement obj;

    private void OnEnable()
    {
        obj = target as StraightMovement;
    }

    public override void OnInspectorGUI()
    {
        obj.direction = Vector3.ClampMagnitude(EditorGUILayout.Vector3Field("Direction", obj.direction), 1f);
        obj.speed = EditorGUILayout.FloatField("Speed", obj.speed);


    }


}
