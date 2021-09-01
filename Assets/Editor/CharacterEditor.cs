using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Character))]
public class CharacterEditor : Editor
{
    Character character;

    Transform hip;
    

    private void OnEnable()
    {
        character = target as Character;
        hip = character.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips);
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

}
