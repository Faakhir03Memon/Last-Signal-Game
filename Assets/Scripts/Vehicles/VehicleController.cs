using UnityEngine;

namespace ViceCityClone.Vehicles
{
    public class VehicleController : MonoBehaviour
    {
        public float acceleration = 1500f;
        public float steeringSpeed = 300f;
        public float maxSpeed = 20f;

        private Rigidbody rb;
        private float moveInput;
        private float steerInput;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = new Vector3(0, -0.5f, 0); // Lower center of mass for stability
        }

        private void Update()
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            // Simple driving logic
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddRelativeForce(Vector3.forward * moveInput * acceleration);
            }

            // Steering
            if (rb.velocity.magnitude > 0.1f)
            {
                float turn = steerInput * steeringSpeed * Time.fixedDeltaTime;
                Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
                rb.MoveRotation(rb.rotation * turnRotation);
            }
        }
    }
}
