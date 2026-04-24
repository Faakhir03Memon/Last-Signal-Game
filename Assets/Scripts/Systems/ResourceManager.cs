using UnityEngine;

namespace LastSignal.Systems
{
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance { get; private set; }

        [Header("Resources")]
        public float currentBattery = 100f;
        public float maxBattery = 100f;
        public int scrapCount = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddBattery(float amount)
        {
            currentBattery = Mathf.Clamp(currentBattery + amount, 0, maxBattery);
        }

        public void UseBattery(float amount)
        {
            currentBattery = Mathf.Clamp(currentBattery - amount, 0, maxBattery);
            if (currentBattery <= 0)
            {
                // Handle out of battery (lights out, scanner off)
            }
        }

        public void AddScrap(int amount)
        {
            scrapCount += amount;
        }
    }
}
