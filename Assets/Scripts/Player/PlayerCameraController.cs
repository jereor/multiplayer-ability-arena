using Fusion;
using UnityEngine;

namespace Player
{
    public class PlayerCameraController : NetworkBehaviour
    {
        [SerializeField]
        private Camera playerCamera;
        
        public override void Spawned()
        {
            var isLocalPlayer = HasInputAuthority;
            playerCamera.gameObject.SetActive(isLocalPlayer);
        }
    }
}
