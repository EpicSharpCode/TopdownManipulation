using System;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class CustomColorMaterialBehaviour : ColorMaterialBehaviour
    {
        public override string BehaviourName => "Custom Material Color";

        [SerializeField] Color _customColor = Color.white;

        public override Color GetGoalColor() => _customColor;
        void Update()
        {
            SetMaterialsColor(_customColor);
        }

        public void SetColor(Color color) => _customColor = color;
    }
}