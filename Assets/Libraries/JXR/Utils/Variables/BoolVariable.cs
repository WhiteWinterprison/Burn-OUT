using UnityEngine;
namespace JXR.Utils
{
    [CreateAssetMenu(fileName = "MyBoolVariable", menuName = "JXR/BoolVariable")]
    public class BoolVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        public string developerDescription = "";
#endif
        public bool value;

        public bool Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}