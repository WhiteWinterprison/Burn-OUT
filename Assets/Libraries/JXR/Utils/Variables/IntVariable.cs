using UnityEngine;
namespace JXR.Utils
{
    [CreateAssetMenu(fileName = "MyIntVariable", menuName = "JXR/IntVariable")]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        public string developerDescription = "";
#endif
        public int value;

        public void SetValue(int _value)
        {
            value = _value;
        }

        public void SetValue(IntVariable _value)
        {
            value = _value.value;
        }

        public void ApplyChange(int _amount)
        {
            value += _amount;
        }

        public void ApplyChange(IntVariable _amount)
        {
            value += _amount.value;
        }
    }
}