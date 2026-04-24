using UnityEngine;

namespace ViceCityClone.Vehicles
{
    using ViceCityClone.Player;

    public class VehicleEntry : MonoBehaviour
    {
        public GameObject playerPrefab;
        public Transform exitPoint;
        public Camera carCamera;
        
        private bool isInside = false;
        private GameObject currentPlayer;

        private void Update()
        {
            if (isInside && Input.GetKeyDown(KeyCode.F))
            {
                ExitVehicle();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!isInside && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
            {
                EnterVehicle(other.gameObject);
            }
        }

        private void EnterVehicle(GameObject player)
        {
            currentPlayer = player;
            player.SetActive(false);
            isInside = true;
            
            GetComponent<VehicleController>().enabled = true;
            if (carCamera != null) carCamera.gameObject.SetActive(true);
            
            Debug.Log("Entered Vehicle");
        }

        private void ExitVehicle()
        {
            isInside = false;
            currentPlayer.transform.position = exitPoint.position;
            currentPlayer.SetActive(true);
            
            GetComponent<VehicleController>().enabled = false;
            if (carCamera != null) carCamera.gameObject.SetActive(false);
            
            Debug.Log("Exited Vehicle");
        }
    }
}
