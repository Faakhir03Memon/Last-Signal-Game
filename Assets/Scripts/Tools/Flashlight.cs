using UnityEngine;

namespace LastSignal.Tools
{
    public class Flashlight : MonoBehaviour
    {
        public Light flashlightLight;
        public KeyCode toggleKey = KeyCode.F;
        public float batteryConsumptionRate = 0.5f;
        
        private bool isOn = false;

        private void Start()
        {
            if (flashlightLight == null)
                flashlightLight = GetComponentInChildren<Light>();
                
            flashlightLight.enabled = isOn;
        }

        private void Update()
        {
            if (Input.GetKeyDown(toggleKey))
            {
                Toggle();
            }

            if (isOn)
            {
                ConsumeBattery();
            }
        }

        public void Toggle()
        {
            isOn = !isOn;
            flashlightLight.enabled = isOn;
            // Play toggle sound here
        }

        private void ConsumeBattery()
        {
            // Placeholder for battery system integration
            // ResourceManager.Instance.UseBattery(batteryConsumptionRate * Time.deltaTime);
        }
    }
}
