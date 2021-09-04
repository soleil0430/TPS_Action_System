using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Bound;

public class BodySetterWindow : EditorWindow
{
    public Animator target;
    Transform hip;

    [MenuItem("Codenoob/Body Setter")]
    static void Open()
    {
        BodySetterWindow window = GetWindow<BodySetterWindow>();

        window.Show();
    }


    public List<Transform> hasBounds = new List<Transform>();
    public List<Transform> hasNotBounds = new List<Transform>();


    ScriptableObject thisWindow;
    SerializedObject so;

    SerializedProperty pHasBounds;
    SerializedProperty pHasNotBounds;

    void OnGUI()
    {
        target = (Animator)EditorGUILayout.ObjectField("Humanoid", target, typeof(Animator), true);

        thisWindow = this;
        so = new SerializedObject(thisWindow);

        pHasBounds = so.FindProperty("hasBounds");
        pHasNotBounds = so.FindProperty("hasNotBounds");
        //pReceiveProcessSOs = so.FindProperty("receiveProcessSOs");


        if (target)
        {
            hip = target.GetBoneTransform(HumanBodyBones.Hips);
            EditorGUILayout.ObjectField("Hip", hip, typeof(Transform), false);

            CatchBound();

            ShowHasBound();
            ShowHasNotBound();

            AttatchReceiveBound();
            RemoveReceiveBound();
            //SetAllReceiveProcessSO();
        }
    }


    void CatchBound()
    {
        hasBounds.Clear();
        hasNotBounds.Clear();
        Transform[] parts = hip.GetComponentsInChildren<Transform>();
        foreach (Transform part in parts)
        {
            Collider collider = part.GetComponent<Collider>();
            if (collider)
            {
                collider.isTrigger = true;
                ReceiveBound rBound = part.GetComponent<ReceiveBound>();
                if (rBound)
                {
                    hasBounds.Add(part);
                }
                else
                {
                    hasNotBounds.Add(part);
                }
            }
        }
    }

    void ShowHasBound()
    {
        if (pHasBounds != null)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(pHasBounds, true);
            so.ApplyModifiedProperties();
            EditorGUI.EndDisabledGroup();
        }
    }

    void ShowHasNotBound()
    {
        if (pHasNotBounds != null)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(pHasNotBounds, true);
            so.ApplyModifiedProperties();
            EditorGUI.EndDisabledGroup();
        }
    }

    void AttatchReceiveBound()
    {
        bool isCount = (hasNotBounds.Count > 0);

        EditorGUI.BeginDisabledGroup(!isCount);
        bool flag = GUILayout.Button("Attatch Receive Bound");
        EditorGUI.EndDisabledGroup();

        if (isCount && flag)
        {
            foreach (Transform part in hasNotBounds)
            {
                part.gameObject.AddComponent<ReceiveBound>();
            }
        }
    }


    //bool toggleSetAllReceive;
    //void SetAllReceiveProcessSO()
    //{
    //    bool isCount = (hasBounds.Count > 0);

    //    EditorGUI.BeginDisabledGroup(!isCount);
    //    bool flag = GUILayout.Button("Set All Receive ProcessSO");
    //    EditorGUI.EndDisabledGroup();

    //    if (isCount)
    //    {
    //        if (flag)
    //        {
    //            toggleSetAllReceive = true;
    //        }
    //    }
    //    else
    //    {
    //        toggleSetAllReceive = false;
    //    }


    //    if (toggleSetAllReceive)
    //    {
    //        EditorGUILayout.PropertyField(pReceiveProcessSOs, true);
    //        so.ApplyModifiedProperties();

    //        if (GUILayout.Button("Set"))
    //        {
    //            foreach (Transform has in hasBounds)
    //            {
    //                ReceiveBound rBound = has.GetComponent<ReceiveBound>();
    //                rBound.processSOs = receiveProcessSOs.ConvertAll(o => o);

    //            }
    //        }
    //    }
    //}


    void RemoveReceiveBound()
    {
        bool isCount = hasBounds.Count > 0;

        EditorGUI.BeginDisabledGroup(!isCount);
        bool flag = GUILayout.Button("Remove Receive Bound");
        EditorGUI.EndDisabledGroup();

        if (isCount && flag)
        {
            foreach (Transform part in hasBounds)
            {
                ReceiveBound rBound = part.GetComponent<ReceiveBound>();
                DestroyImmediate(rBound);
            }
        }
    }

}