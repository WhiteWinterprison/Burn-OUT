using UnityEngine;
namespace JXR.Utils
{
    [CreateAssetMenu(fileName = "MyBoolInfo", menuName = "JXR/BoolInfo")]
    public class BoolInfo : ScriptableObject
    {
#if UNITY_EDITOR
        [TextArea]
        public string developerDescription = "";
#endif
        [Space(10)]
        [SerializeField]
        private bool currentValue = false;
        public bool CurrentValue
        {
            get { return currentValue; }
            private set { currentValue = value; }
        }
        [SerializeField]
        private float lastEnabledTime = 0.0f;
        public float LastEnabledTime
        {
            get { return lastEnabledTime; }
            private set { lastEnabledTime = value; }
        }
        [SerializeField]
        private float lastDisabledTime = 0.0f;
        public float LastDisabledTime
        {
            get { return lastDisabledTime; }
            private set { lastDisabledTime = value; }
        }
        public void EnableBool()
        {
            this.LastEnabledTime = Time.time;
            this.CurrentValue = true;
        }
        public void DisableBool()
        {
            this.LastDisabledTime = Time.time;
            this.CurrentValue = false;
        }
        public void SwitchBool()
        {
            if (this.CurrentValue)
            {
                DisableBool();
            }
            else
            {
                EnableBool();
            }
        }

        private void Awake()
        {
            LastEnabledTime = 0.0f;
            LastDisabledTime = 0.0f;
        }
    }
}