using Fusion;
using Network;
using UnityEngine;

namespace Player
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField]
        private Rigidbody rb;
        
        [SerializeField, Range(0f, 10f)]
        private float speed = 5f;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData input))
            {
                var move = new Vector3(input.Move.x, 0, input.Move.y);

                rb.linearVelocity = move.normalized * speed;
            }
        }
    }
}
