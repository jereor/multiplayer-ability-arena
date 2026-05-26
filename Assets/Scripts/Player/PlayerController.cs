using Fusion;
using Network;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(NetworkCharacterController))]
    public class PlayerController : NetworkBehaviour
    {
        private NetworkCharacterController _controller;
        
        [SerializeField, Range(1f, 5f)]
        private float speed = 3f;

        private void Awake()
        {
            _controller = GetComponent<NetworkCharacterController>();
        }
        
        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData input))
            {
                var moveDirection = new Vector3(input.Move.x, 0, input.Move.y);
                moveDirection.Normalize();

                _controller.Move(moveDirection * speed * Runner.DeltaTime);
            }
        }
    }
}
