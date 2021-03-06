using System;
namespace JXR.Utils
{
    [Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public FloatReference()
        { }

        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public float value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.value;
        }
    }
}