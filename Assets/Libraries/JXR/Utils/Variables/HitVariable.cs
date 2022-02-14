using UnityEngine;
namespace JXR.Utils
{
    [CreateAssetMenu(fileName = "MyHitVariable", menuName = "JXR/HitVariable")]
    public class HitVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        public string developerDescription = "";
#endif
        public RaycastHit value;

        public void SetValue(RaycastHit _value)
        {
            value = _value;
        }

        public void SetValue(HitVariable _value)
        {
            value = _value.value;
        }
    }
}