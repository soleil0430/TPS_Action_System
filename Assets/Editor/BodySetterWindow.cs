using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BodySetterWindow : EditorWindow
{

    //Animator target;
    //Transform hip;
    //List<Transform> bodyParts = new List<Transform>();
    //string[] bodyInterfaces;

    //[MenuItem("Codenoob/Body Setter")]
    //static void Open()
    //{
    //    BodySetterWindow window = GetWindow<BodySetterWindow> ();
    //    window.hip = null;
    //    window.bodyParts.Clear();
    //    window.bodyInterfaces = Utility.GetInterfaceList("GameMessage");
    //    window.Show();
    //}

    //int mask;
    //void OnGUI ()
    //{
    //    target = (Animator)EditorGUILayout.ObjectField("Target", target, typeof(Animator), true);
        
    //    if (target)
    //    {
    //        GUILayout.Space(20);
    //        hip = target.GetBoneTransform(HumanBodyBones.Hips);

    //        EditorGUI.BeginDisabledGroup(true);
    //        EditorGUILayout.ObjectField("Hip", hip, typeof(Transform), false);
    //        EditorGUI.EndDisabledGroup();

    //        GUILayout.Space(20);
    //        EditorGUILayout.LabelField("Body Parts");
    //        if (bodyParts.Count == 0)
    //        {
    //            Transform[] childs = hip.GetComponentsInChildren<Transform>();
    //            foreach (Transform child in childs)
    //            {
    //                Collider collider = child.GetComponent<Collider>();
    //                if (collider)
    //                    bodyParts.Add(child);
    //            }
    //        }

    //        EditorGUI.BeginDisabledGroup(false);
    //        foreach (var item in bodyParts)
    //        {
    //            BodyPartBound[] bounds = item.GetComponents<BodyPartBound>();

    //            foreach (var bound in bounds)
    //            {
    //                EditorGUILayout.MaskField(bound.name, mask, bodyInterfaces);
    //            }
    //        }
    //        EditorGUI.EndDisabledGroup();


    //    }
    //}


}