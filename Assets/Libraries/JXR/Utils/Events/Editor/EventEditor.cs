using UnityEditor;
using UnityEngine;
namespace JXR.Utils
{
    [CustomEditor(typeof(GameEvent), editorForChildClasses: true)]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GameEvent gameEvent = target as GameEvent;
            GUI.enabled = !Application.isPlaying;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Serialize Listeners"))
            {
                gameEvent.SerializeListeners();
            }
            if (GUILayout.Button("Deserialize Listeners"))
            {
                gameEvent.DeserializeListeners();
            }
            GUILayout.EndHorizontal();
            GUI.enabled = Application.isPlaying;
            if (GUILayout.Button("Raise"))
                gameEvent.Raise();
        }
    }
}