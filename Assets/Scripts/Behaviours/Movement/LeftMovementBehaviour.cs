using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class LeftMovementBehaviour : MovementBehaviour
    {
        public override string BehaviourName => "Left Movement";
        public override Vector3 GetMovementVector() => new Vector3(0, 0, 1);
    }
}