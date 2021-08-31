using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public class CharacterEditor : Editor
{
    Character character;


    private void OnEnable()
    {
        character = target as Character;
        hip = character.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(20);
        SetBody();
    }

    bool setBodyToggle = false;
    Transform hip;
    void SetBody()
    {
        setBodyToggle = EditorGUILayout.BeginFoldoutHeaderGroup(setBodyToggle, "All Body Part Set");

        if (setBodyToggle)
        {
            hip = (Transform)EditorGUILayout.ObjectField(hip, typeof(Transform), true);
            if (GUILayout.Button("Set !"))
            {
                if (hip)
                {
                    List<Transform> updatePart = new List<Transform>();
                    Transform[] childs = hip.GetComponentsInChildren<Transform>();
                    foreach (Transform child in childs)
                    {
                        bool isUpdate = false;

                        Collider collider = child.GetComponent<Collider>();
                        if (collider)
                        {
                            collider.isTrigger = true;

                            Body body = child.GetComponent<Body>();
                            if (!body)
                            {
                                child.gameObject.AddComponent<Body>();
                                isUpdate = true;
                            }
                        }

                        if (isUpdate)
                            updatePart.Add(child);
                    }

                    if (updatePart.Count > 0)
                    {
                        Debug.Log(updatePart.Count + "개 추가");
                        foreach (var item in updatePart)
                        {
                            Debug.Log(item.name);
                        }
                        Debug.Log("========================================");
                    }
                    else
                    {
                        Debug.Log("추가 없음");
                    }
                }
                else
                {
                    Debug.Log("Hip이 존재하지 않습니다.");
                }
            }
        }

        EditorGUILayout.EndFoldoutHeaderGroup();
    }


}
