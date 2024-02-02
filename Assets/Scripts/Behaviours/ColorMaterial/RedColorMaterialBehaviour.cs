using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class RedColorMaterialBehaviour : ColorMaterialBehaviour
    {
        public override string BehaviourName => "Red Material Color";
        public override Color GetGoalColor() => Color.red;
    }
}