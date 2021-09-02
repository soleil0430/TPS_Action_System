using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;


public static class Utility
{
    public static string[] GetInterfaceList(string _namespace)
    {
        List<string> list = new List<string>();
        List<Type> typeList = new List<Type>();
        foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (t.Namespace == "GameMessage" && t.IsInterface)
            {
                list.Add(t.Name);
            }
        }

        return list.ToArray();
    }


    public static void SetBehaviour<T>(Animator _animator, T _entity) where T : MonoBehaviour
    {
        MecanimState<T>[] stateArray = _animator.GetBehaviours<MecanimState<T>>();
        foreach (MecanimState<T> state in stateArray)
        {
            state.entity = _entity;
        }
    }


}
