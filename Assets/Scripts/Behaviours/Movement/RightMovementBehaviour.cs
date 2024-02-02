using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class RightMovementBehaviour : MovementBehaviour
    {
        public override string BehaviourName => "Right Movement";
        public override Vector3 GetMovementVector() => new Vector3(0, 0, -1);
    }
}