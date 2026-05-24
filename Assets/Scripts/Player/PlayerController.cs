using Fusion;
using Network;
using UnityEngine;

namespace Player
{
    public class PlayerController : NetworkBehaviour
    {
        public float speed = 5f;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData input))
            {
                var move = new Vector3(input.Move.x, 0, input.Move.y);

                transform.position +=
                    move * speed * Runner.DeltaTime;
            }
        }
    }
}
