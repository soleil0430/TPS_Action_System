using UnityEngine;
using UnityEditor;

public class NewEditorWindows : EditorWindow
{
    [MenuItem("Codenoob/Sample")]
    static void Open()
    {
        GetWindow<NewEditorWindows> ();
    }

    string[] masks = new string[] { "����ũ1", "����ũ2", "����ũ3" };
    int maskField;
    void OnGUI()
    {
        maskField = EditorGUILayout.MaskField("Mask", maskField, masks);
        EditorGUILayout.IntField(maskField);

    }
}