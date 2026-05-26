using CameraUtility;
using Fusion;
using UnityEngine;

namespace Player
{
    public class PlayerCameraController : NetworkBehaviour
    {
        public override void Spawned()
        {
            if (!HasInputAuthority)
                return;
            
            var cameraFollow = FindAnyObjectByType<CameraFollow>();
            
            if (cameraFollow == null)
            {
                Debug.Log("No CameraFollow found!");
                return;
            }
            
            cameraFollow.Target = transform;
        }
    }
}
