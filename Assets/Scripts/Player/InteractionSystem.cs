using UnityEngine;

namespace LastSignal.Player
{
    using LastSignal.Interactions;

    public class InteractionSystem : MonoBehaviour
    {
        public float interactRange = 3f;
        public LayerMask interactLayer;
        public Camera playerCamera;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryInteract();
            }
        }

        private void TryInteract()
        {
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactRange, interactLayer))
            {
                Interactable obj = hit.collider.GetComponent<Interactable>();
                if (obj != null)
                {
                    obj.Interact();
                }
            }
        }
    }
}
