using UnityEngine;
using UnityEditor;

public class EditModeFunctions : EditorWindow
{
    private GameObject parent;

    [MenuItem("Window/CourseTools")]
    public static void ShowWindow()
    {
        GetWindow<EditModeFunctions>("Edit Mode Functions");
    }

    private void OnGUI()
    {
        GUILayout.Label("Generate Game Object");
        parent = (GameObject)EditorGUILayout.ObjectField("parent", parent, typeof(GameObject), true);

        if (GUILayout.Button("Generate"))
        {
            GenerateGameObjects(2000);
        }
        HorizontalLine(Color.gray);
    }

    private void GenerateGameObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject g = new GameObject();
            g.AddComponent<TestComponent>();
            g.transform.parent = parent.transform;
        }
        Debug.Log(parent.transform.childCount);
    }

    private static void HorizontalLine(Color color)
    {
        GUIStyle horizontalLine;
        horizontalLine = new GUIStyle();
        horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
        horizontalLine.margin = new RectOffset(0, 0, 10, 10);
        horizontalLine.fixedHeight = 1;

        var c = GUI.color;
        GUI.color = color;
        GUILayout.Box(GUIContent.none, horizontalLine);
        GUI.color = c;
    }
}