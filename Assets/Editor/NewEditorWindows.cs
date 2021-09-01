using UnityEngine;
using UnityEditor;

public class NewEditorWindows : EditorWindow
{
    [MenuItem("Codenoob/Sample")]
    static void Open()
    {
        GetWindow<NewEditorWindows> ();
    }

    string[] masks = new string[] { "마스크1", "마스크2", "마스크3" };
    int maskField;
    void OnGUI()
    {
        maskField = EditorGUILayout.MaskField("Mask", maskField, masks);
        EditorGUILayout.IntField(maskField);

    }
}