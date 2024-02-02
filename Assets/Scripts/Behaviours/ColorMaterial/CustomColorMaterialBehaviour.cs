using System;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public class CustomColorMaterialBehaviour : ColorMaterialBehaviour
    {
        public override string BehaviourName => "Custom Material Color";

        [SerializeField] Color _customColor = Color.white;
        Color _currentColor;

        public override Color GetGoalColor() => _currentColor;
        void Update()
        {
            if (_currentColor != _customColor) _currentColor = _customColor;
        }

        public void SetColor(Color color) => _customColor = color;
    }
}