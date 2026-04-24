using UnityEngine;
using System.Collections.Generic;

namespace LastSignal.Tools
{
    using LastSignal.Signals;

    public class SignalScanner : MonoBehaviour
    {
        public float maxDetectionRange = 50f;
        public LayerMask signalLayer;
        public AudioSource beepSource;
        public AnimationCurve beepFrequencyCurve;

        private SignalSource currentNearestSignal;
        private float distanceToNearest;

        private void Update()
        {
            FindNearestSignal();
            UpdateScannerFeedback();
        }

        private void FindNearestSignal()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, maxDetectionRange, signalLayer);
            
            SignalSource nearest = null;
            float minDistance = Mathf.Infinity;

            foreach (var hit in hits)
            {
                SignalSource source = hit.GetComponent<SignalSource>();
                if (source != null && !source.isDecoded)
                {
                    float dist = Vector3.Distance(transform.position, source.transform.position);
                    if (dist < minDistance)
                    {
                        minDistance = dist;
                        nearest = source;
                    }
                }
            }

            currentNearestSignal = nearest;
            distanceToNearest = minDistance;
        }

        private void UpdateScannerFeedback()
        {
            if (currentNearestSignal != null)
            {
                // Logic for beep frequency or UI meter
                float normalizedDist = 1f - Mathf.Clamp01(distanceToNearest / maxDetectionRange);
                // Example: beepSource.pitch = 1f + normalizedDist;
            }
        }

        public SignalSource GetTargetSignal() => currentNearestSignal;
    }
}
