using UnityEngine; 
using UnityEditor;

[CustomEditor(typeof(TowerGrid))]
public class TowerGridEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TowerGrid myScript = (TowerGrid)target;
        if(GUILayout.Button("Generate Tower Grid"))
        {
            myScript.OnButtonGeneratePressed();
        }
    }
}