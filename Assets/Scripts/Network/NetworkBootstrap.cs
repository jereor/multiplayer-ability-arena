using UnityEngine;
using Fusion;
using Player;

namespace Network
{
    public class NetworkBootstrap : MonoBehaviour
    {
        [SerializeField]
        private NetworkRunner networkRunnerPrefab;
        
        [SerializeField]
        private PlayerInputHandler playerInputHandler;
        
        [SerializeField]
        private PlayerSpawner playerSpawner;

        private async void Start()
        {
            var networkRunner = Instantiate(networkRunnerPrefab);
            networkRunner.ProvideInput = true;
            
            networkRunner.AddCallbacks(playerInputHandler);
            networkRunner.AddCallbacks(playerSpawner);
            
            await networkRunner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.AutoHostOrClient,
                SessionName = "TestRoom",
                SceneManager = networkRunner.gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }
    }
}
