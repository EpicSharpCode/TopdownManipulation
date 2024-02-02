using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class CustomMovementBehaviour : MovementBehaviour
    {
        [SerializeField] Vector3 _movementVector;
        Vector3 _currentVector;
        public override string BehaviourName => "Custom Movement";
        public override Vector3 GetMovementVector() => _currentVector;

        public override void Update()
        {
            if(_currentVector != _movementVector)
            {
                Deactivate();
                _currentVector = _movementVector;
                Activate();
            }
            base.Update();
        }

        public void SetMovementVector(Vector3 newVector) => _movementVector = newVector;
    }
}