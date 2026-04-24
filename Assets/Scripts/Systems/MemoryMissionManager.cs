using UnityEngine;
using UnityEngine.SceneManagement;

namespace LastSignal.Systems
{
    public class MemoryMissionManager : MonoBehaviour
    {
        public static MemoryMissionManager Instance { get; private set; }

        private string lastOverworldScene;

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

        public void StartMemoryMission(string sceneName)
        {
            lastOverworldScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }

        public void ExitMemoryMission()
        {
            if (!string.IsNullOrEmpty(lastOverworldScene))
            {
                SceneManager.LoadScene(lastOverworldScene);
            }
            else
            {
                SceneManager.LoadScene(0); // Fallback to main menu or initial scene
            }
        }
    }
}
