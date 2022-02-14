using UnityEngine;
using UnityEngine.Events;
namespace JXR.Utils
{
    [CreateAssetMenu(fileName = "MyTriggerVariable", menuName = "JXR/TriggerVariable")]
    public class TriggerVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        public string developerDescription = "";
#endif
        public UnityAction<Collider> onEnter = delegate { };
        public UnityAction<Collider> onStay = delegate { };
        public UnityAction<Collider> onExit = delegate { };
    }
}