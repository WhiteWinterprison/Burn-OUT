using UnityEngine;
using UnityEngine.Events;
namespace JXR.Utils
{
    [CreateAssetMenu(fileName = "MyCollisionVariable", menuName = "JXR/CollisionVariable")]
    public class CollisionVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        public string developerDescription = "";
#endif
        public UnityAction<Collision> onEnter = delegate { };
        public UnityAction<Collision> onStay = delegate { };
        public UnityAction<Collision> onExit = delegate { };
    }
}