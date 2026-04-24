#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using LastSignal.Player;
using LastSignal.Systems;
using LastSignal.Signals;
using LastSignal.Tools;

namespace LastSignal.Editor
{
    public class ProjectInitializer : EditorWindow
    {
        [MenuItem("Last Signal/Initialize Project Scene")]
        public static void InitializeScene()
        {
            // 1. Create a new scene
            SceneAsset newScene = SceneImporter.CreateScene("MainWorld");
            EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);

            // 2. Setup Player
            GameObject player = new GameObject("Player Hunter");
            player.tag = "Player";
            CharacterController cc = player.AddComponent<CharacterController>();
            PlayerController pc = player.AddComponent<PlayerController>();
            
            GameObject camObj = Camera.main.gameObject;
            camObj.transform.parent = player.transform;
            camObj.transform.localPosition = new Vector3(0, 0.8f, 0);
            MouseLook ml = camObj.AddComponent<MouseLook>();
            ml.playerBody = player.transform;
            pc.cameraTransform = camObj.transform;

            // 3. Setup Tools
            GameObject flashlight = new GameObject("Flashlight");
            flashlight.transform.parent = camObj.transform;
            flashlight.transform.localPosition = new Vector3(0.3f, -0.2f, 0.5f);
            Light l = flashlight.AddComponent<Light>();
            l.type = LightType.Spot;
            l.range = 20f;
            l.spotAngle = 35f;
            flashlight.AddComponent<Flashlight>();

            player.AddComponent<SignalScanner>();

            // 4. Setup Ground
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.localScale = new Vector3(10, 1, 10);

            // 5. Setup Systems
            GameObject systems = new GameObject("Systems");
            systems.AddComponent<ResourceManager>();
            systems.AddComponent<MemoryMissionManager>();
            NetworkManager nm = systems.AddComponent<NetworkManager>();
            nm.backendUrl = "http://localhost:8000";

            // 6. Setup Home Base (Life Sim Area)
            GameObject base = new GameObject("Home Base");
            base.transform.position = Vector3.zero;
            
            // Add a Bed
            GameObject bed = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bed.name = "Bed";
            bed.transform.parent = base.transform;
            bed.transform.localPosition = new Vector3(-2, 0.5f, 0);
            bed.transform.localScale = new Vector3(2, 0.5f, 1);
            var interactBed = bed.AddComponent<LastSignal.Interactions.Interactable>();
            interactBed.type = LastSignal.Interactions.InteractionType.Bed;
            interactBed.promptMessage = "Press E to Sleep";

            // Add some Food
            GameObject apple = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            apple.name = "Apple";
            apple.transform.parent = base.transform;
            apple.transform.localPosition = new Vector3(-1, 0.5f, 1);
            apple.transform.localScale = Vector3.one * 0.3f;
            var interactFood = apple.AddComponent<LastSignal.Interactions.Interactable>();
            interactFood.type = LastSignal.Interactions.InteractionType.Food;
            interactFood.value = 15f;
            interactFood.promptMessage = "Press E to Eat";

            // 7. Setup Sample Signal
            GameObject signalObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            signalObj.name = "Signal_Tower_001";
            signalObj.transform.position = new Vector3(15, 0.5f, 15);
            SignalSource ss = signalObj.AddComponent<SignalSource>();
            ss.signalID = "SIG_001";
            ss.signalName = "Abandoned Radio Tower";
            signalObj.AddComponent<LastSignal.Puzzles.FrequencyPuzzle>();
            
            // Set layer for scanner (assuming Layer 6 is 'Signals')
            signalObj.layer = 6; 

            Debug.Log("Last Signal project initialized successfully! Don't forget to create a 'Signals' layer (Layer 6) and assign it to the SignalScanner.");
        }
    }

    internal class SceneImporter
    {
        public static SceneAsset CreateScene(string name)
        {
            return null; // Logic to save scene asset if needed
        }
    }
}
#endif
