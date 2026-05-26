using Fusion;
using Network;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(NetworkCharacterController))]
    public class PlayerController : NetworkBehaviour
    {
        private NetworkCharacterController _controller;
        
        [SerializeField, Range(0f, 10f)]
        private float speed = 5f;

        private void Awake()
        {
            _controller = GetComponent<NetworkCharacterController>();
        }
        
        public override void FixedUpdateNetwork()
        {
            if (!HasInputAuthority)
                return;
            
            if (GetInput(out NetworkInputData input))
            {
                var move = new Vector3(input.Move.x, 0, input.Move.y);

                _controller.Move(move.normalized * speed * Time.fixedDeltaTime);
            }
        }
    }
}
