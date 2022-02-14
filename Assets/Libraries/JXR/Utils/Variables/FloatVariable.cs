using UnityEngine;
namespace JXR.Utils
{
    [CreateAssetMenu(fileName = "MyFloatVariable", menuName = "JXR/FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        public string developerDescription = "";
#endif
        public float value;

        public void SetValue(float _value)
        {
            value = _value;
        }

        public void SetValue(FloatVariable _value)
        {
            value = _value.value;
        }

        public void ApplyChange(float _amount)
        {
            value += _amount;
        }

        public void ApplyChange(FloatVariable _amount)
        {
            value += _amount.value;
        }
    }
}