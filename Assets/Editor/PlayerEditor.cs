using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    Player player;

    private void OnEnable()
    {
        player = target as Player;
    }


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(20);
        if (GUILayout.Button("Open Receive Bound Window"))
        {
            BodySetterWindow window = EditorWindow.GetWindow<BodySetterWindow>();
            window.target = player.GetComponent<Animator>();
            window.Show();
        }
    }

}
