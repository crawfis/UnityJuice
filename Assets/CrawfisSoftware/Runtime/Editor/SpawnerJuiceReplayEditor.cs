using CrawfisSoftware.Spawners;

using UnityEditor;

using UnityEngine;

namespace CrawfisSoftware.Editor
{
    [CustomEditor(typeof(SpawnerJuiceReplay))]
    internal class SpawnerJuiceReplayEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var script = (SpawnerJuiceReplay)target;

            EditorGUILayout.Space(2f * EditorGUIUtility.singleLineHeight);
            if (GUILayout.Button("Add Juice"))
            {
                script.AddJuice();
            }

            EditorGUILayout.Space(EditorGUIUtility.singleLineHeight);
            if (GUILayout.Button("Animate"))
            {
                script.PlayAll();
            }
        }
    }
}