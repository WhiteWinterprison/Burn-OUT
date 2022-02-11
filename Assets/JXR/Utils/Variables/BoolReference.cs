using System;
namespace JXR.Utils
{
    [Serializable]
    public class BoolReference
    {
        public bool UseConstant = true;
        public bool ConstantValue;
        public BoolVariable Variable;

        public BoolReference()
        { }

        public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public bool value
        {
            get { return UseConstant ? ConstantValue : Variable.value; }
        }

        public static implicit operator bool(BoolReference reference)
        {
            return reference.value;
        }
    }
}