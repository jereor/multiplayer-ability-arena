using UnityEngine;
using Fusion;

namespace Network
{
    public class NetworkBootstrap : MonoBehaviour
    {
        [SerializeField]
        private NetworkRunner networkRunnerPrefab;

        private async void Start()
        {
            var networkRunner = Instantiate(networkRunnerPrefab);
            networkRunner.ProvideInput = true;
            
            await networkRunner.StartGame(new StartGameArgs
            {
                GameMode = GameMode.AutoHostOrClient,
                SessionName = "TestRoom",
                SceneManager = networkRunner.gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }
    }
}
