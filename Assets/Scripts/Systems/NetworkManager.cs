using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

namespace LastSignal.Systems
{
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager Instance { get; private set; }
        public string backendUrl = "http://localhost:8000";

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

        public void SendSignalDiscovery(string id, string name)
        {
            StartCoroutine(PostSignalData(id, name));
        }

        private IEnumerator PostSignalData(string id, string name)
        {
            string json = "{\"signal_id\":\"" + id + "\", \"name\":\"" + name + "\", \"is_decoded\":true}";
            
            using (UnityWebRequest request = new UnityWebRequest(backendUrl + "/signals/discover", "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Error sending signal data: " + request.error);
                }
                else
                {
                    Debug.Log("Signal data sent successfully: " + request.downloadHandler.text);
                }
            }
        }
    }
}
