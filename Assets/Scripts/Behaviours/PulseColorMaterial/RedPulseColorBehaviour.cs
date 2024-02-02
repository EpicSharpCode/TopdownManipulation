using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class RedPulseColorBehaviour : PulseColorBehaviour
    {

        public override string BehaviourName => "Red Pulse Color";
        public override Color GetGoalColor() => Color.red;
    }
}