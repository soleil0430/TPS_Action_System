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
        base.OnInspectorGUI();

        Vector3 o = new Vector2();
        o.x = 1;
        o.y = 1;
        o.Normalize();
        Debug.Log(o.x);

        GUILayout.Space(20);
        if (GUILayout.Button("Open Receive Bound Window"))
        {
            BodySetterWindow window = EditorWindow.GetWindow<BodySetterWindow>();
            window.target = player.GetComponent<Animator>();
            window.Show();
        }
    }

}
