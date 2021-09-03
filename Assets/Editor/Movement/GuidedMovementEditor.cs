using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Movement;

[CustomEditor(typeof(GuidedMovement))]
public class GuidedMovementEditor : Editor
{
    GuidedMovement obj;

    private void OnEnable()
    {
        obj = target as GuidedMovement;
    }

    public override void OnInspectorGUI()
    {
        obj.guided = Mathf.Clamp(EditorGUILayout.FloatField("Guided", obj.guided), 0.1f, 1f);
        
        obj.target = (Transform)EditorGUILayout.ObjectField("Target", obj.target, typeof(Transform), true);
        obj.targetPoint = EditorGUILayout.Vector3Field("Target Point", obj.targetPoint);
        obj.speed = EditorGUILayout.FloatField("Speed", obj.speed);

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.Vector3Field("Velocity", obj.velocity);
        EditorGUI.EndDisabledGroup();
    }

}
