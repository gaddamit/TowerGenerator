using UnityEngine; 
using UnityEditor;

[CustomEditor(typeof(TowerSpawner))]
public class TowerSpawnerEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TowerSpawner myScript = (TowerSpawner)target;
        if(GUILayout.Button("Generate Tower"))
        {
            myScript.OnButtonGeneratePressed();
        }
    }
}