using UnityEngine;

namespace LastSignal.Interactions
{
    public enum InteractionType { None, Bed, Food, Water, Scrap }

    public class Interactable : MonoBehaviour
    {
        public InteractionType type;
        public float value = 20f;
        public string promptMessage = "Press E to interact";

        public void Interact()
        {
            switch (type)
            {
                case InteractionType.Bed:
                    Systems.ResourceManager.Instance.energy = 100f;
                    Debug.Log("Slept well. Energy restored.");
                    break;
                case InteractionType.Food:
                    Systems.ResourceManager.Instance.hunger += value;
                    Destroy(gameObject);
                    break;
                case InteractionType.Water:
                    Systems.ResourceManager.Instance.thirst += value;
                    Destroy(gameObject);
                    break;
                case InteractionType.Scrap:
                    Systems.ResourceManager.Instance.AddScrap((int)value);
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
