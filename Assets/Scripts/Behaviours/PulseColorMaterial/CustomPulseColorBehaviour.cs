using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class CustomPulseColorBehaviour : PulseColorBehaviour
    {
        [SerializeField] Color _customColor = Color.white;
        Color _currentColor;

        public override string BehaviourName => "Custom Pulse Color";
        public override Color GetGoalColor() => _currentColor;

        public override void Update()
        {
            if(!_pulse) return;
            
            if (_customColor != _currentColor)
            {
                Deactivate();
                _currentColor = _customColor;
                Activate();
            }
            base.Update();
        }
    }
}