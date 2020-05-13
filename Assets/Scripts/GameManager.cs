using Starload.Network;
using UnityEngine;

namespace Starload
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public NetworkServer network;
        
        public void Awake()
        {
            if (Instance != null)
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
            network = NetworkServer.Create();
        }

        public void Update()
        {
            network.Update();
        }
    }
}