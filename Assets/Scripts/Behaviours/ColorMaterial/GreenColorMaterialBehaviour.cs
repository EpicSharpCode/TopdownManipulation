using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class GreenColorMaterialBehaviour : ColorMaterialBehaviour
    {
        public override string BehaviourName => "Green Material Color";
        public override Color GetGoalColor() => Color.green;
    }
}