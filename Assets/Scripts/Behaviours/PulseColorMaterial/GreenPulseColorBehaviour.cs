using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class GreenPulseColorBehaviour : PulseColorBehaviour
    {
        public override string BehaviourName => "Green Pulse Color";
        public override Color GetGoalColor() => Color.green;
    }
}