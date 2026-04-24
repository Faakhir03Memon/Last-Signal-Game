using UnityEngine;

namespace LastSignal.Signals
{
    public class SignalSource : MonoBehaviour
    {
        public string signalID;
        public string signalName;
        public float detectionRadius = 20f;
        public bool isDecoded = false;

        [Header("Puzzle Settings")]
        public float frequencyTarget = 0.5f; // Target frequency for the mini-game
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
