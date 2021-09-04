using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using Bound;


//[CustomEditor(typeof(SendBound))]
public class SendBoundEditor : Editor
{
//    protected SendBound sBound;

//    protected virtual void OnEnable()
//    {
//        sBound = target as SendBound;
//    }

//    protected EBoundMessageType selectType;
//    public override void OnInspectorGUI()
//    {
//        //현황 보여주기
//        SerializedProperty property = serializedObject.FindProperty("bMessages");
//        EditorGUILayout.PropertyField(property);
//        serializedObject.ApplyModifiedProperties();

//        GUILayout.Space(EditorGUIUtility.singleLineHeight);

//        //선택
//        selectType = (EBoundMessageType)EditorGUILayout.EnumPopup("Message Type", selectType);

//        if (sBound.bMessages == null)
//        {
//            Debug.Log("WRK");
//        }
//        if (sBound.bMessages.Find(o => o.boundType == selectType))
//        {
//            EditorGUILayout.HelpBox("Already have it.", MessageType.Info);
//        }
//        else
//        {
//            //편집
//            switch (selectType)
//            {
//                case EBoundMessageType.Damage:
//                    DamageMessage damageMessage = CreateInstance<DamageMessage>();
//                    if (GUILayout.Button("Create"))
//                    {
//                        sBound.bMessages.Add(damageMessage);
//                    }

//                    break;
//                case EBoundMessageType.Slow:
//                    SlowMessage slowMessage = CreateInstance<SlowMessage>();
//                    if (GUILayout.Button("Create"))
//                    {
//                        sBound.bMessages.Add(slowMessage);
//                    }
//                    break;
//                case EBoundMessageType.Direction:
//                    DirectionMessage directionMessage = CreateInstance<DirectionMessage>();
//                    if (GUILayout.Button("Create"))
//                    {
//                        sBound.bMessages.Add(directionMessage);
//                    }
//                    break;
//                default:
//                    EditorGUILayout.HelpBox("None is not working", MessageType.Error);
//                    break;
//            }
//        }
//    }

}
