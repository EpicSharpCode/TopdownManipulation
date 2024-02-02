
using System;
using TopdownManipulation.Primitives;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public abstract class ColorMaterialBehaviour: BehaviourBase, IBehaviour
    {
        public abstract Color GetGoalColor();

        void OnEnable()
        {
            _thisPrimitive.RemoveBehaviours<PulseColorBehaviour>(); 
            _thisPrimitive.RemoveBehaviours<ColorMaterialBehaviour>(this);
        }
        void OnDisable() => Deactivate();
        void OnDestroy() { if(enabled) Deactivate(); }

        public void Activate() => SetMaterialsColor(GetGoalColor());
        public void Deactivate() => SetMaterialsColor(Color.white);

        protected void SetMaterialsColor(Color color)
        {
            if(_thisPrimitive.MeshRenderer == null) return;
            foreach (var material in _thisPrimitive.MeshRenderer.materials)
            {
                material.color = color;
            }
        }
    }
}