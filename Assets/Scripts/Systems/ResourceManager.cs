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

        [Header("Life Sim Stats")]
        public float hunger = 100f;
        public float energy = 100f;
        public float thirst = 100f;
        public float decayRate = 0.5f;

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

        private void Update()
        {
            // Passive decay
            hunger = Mathf.Clamp(hunger - decayRate * Time.deltaTime, 0, 100);
            thirst = Mathf.Clamp(thirst - (decayRate * 1.2f) * Time.deltaTime, 0, 100);
            energy = Mathf.Clamp(energy - (decayRate * 0.5f) * Time.deltaTime, 0, 100);
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
