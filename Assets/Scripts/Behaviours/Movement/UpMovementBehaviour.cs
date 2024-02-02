using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class UpMovementBehaviour : MovementBehaviour
    {

        public override string BehaviourName => "Up Movement";
        public override Vector3 MovementVector => new Vector3(0, 1, 0);
    }
}