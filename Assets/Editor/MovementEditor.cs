using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Move;

[CustomEditor(typeof(Movement))]
public class MovementEditor : Editor
{
    Movement movement;

    SerializedProperty straight;
    SerializedProperty decided;
    SerializedProperty bezier3;

    private void OnEnable()
    {
        movement = target as Movement;

        straight = serializedObject.FindProperty("straightMover");
        decided = serializedObject.FindProperty("decidedMover");
        bezier3 = serializedObject.FindProperty("bezier3Mover");

        movement.SetIMover();
    }

    SerializedProperty property;
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        movement.eMover = (EMover)EditorGUILayout.EnumPopup("Mover Type", movement.eMover);
        if (EditorGUI.EndChangeCheck())
        {
            movement.SetIMover();
        }

        switch (movement.eMover)
        {
            case EMover.None:
                property = null;
                break;
            case EMover.Straight:
                property = straight;
                break;
            case EMover.Decided:
                property = decided;
                break;
            case EMover.Bezier3:
                property = bezier3;
                break;
            default:
                break;
        }

        EditorGUI.BeginChangeCheck();
        if (property != null)
        {
            EditorGUILayout.PropertyField(property, new GUIContent(movement.eMover.ToString()));
        }

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
        }


        GUILayout.Space(50);
        base.OnInspectorGUI();
    }


    

}
