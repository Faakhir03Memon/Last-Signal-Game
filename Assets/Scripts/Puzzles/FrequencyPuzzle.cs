using UnityEngine;
using System;

namespace LastSignal.Puzzles
{
    public class FrequencyPuzzle : MonoBehaviour
    {
        public event Action OnPuzzleSolved;

        [Header("State")]
        public float currentFrequency = 0f;
        public float targetFrequency = 0.5f;
        public float tolerance = 0.05f;
        public bool isSolved = false;

        public void UpdateFrequency(float value)
        {
            if (isSolved) return;

            currentFrequency = value;
            CheckSuccess();
        }

        private void CheckSuccess()
        {
            if (Mathf.Abs(currentFrequency - targetFrequency) < tolerance)
            {
                isSolved = true;
                OnPuzzleSolved?.Invoke();
                Debug.Log("Signal Decoded!");
                
                // Reporting to backend
                var source = GetComponent<LastSignal.Signals.SignalSource>();
                if (source != null)
                {
                    LastSignal.Systems.NetworkManager.Instance.SendSignalDiscovery(source.signalID, source.signalName);
                }
            }
        }
    }
}
