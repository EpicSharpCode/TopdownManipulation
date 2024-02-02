using System;
using TopdownManipulation.Primitives;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public abstract class PulseColorBehaviour: BehaviourBase, IBehaviour
    {
        public abstract Color GetGoalColor();

        protected bool _pulse;
        Color _startColor;
        float _time;

        void OnEnable()
        {
            _startColor = Color.white;
            _thisPrimitive.RemoveBehaviours<ColorMaterialBehaviour>(); 
            _thisPrimitive.RemoveBehaviours<PulseColorBehaviour>(this);
        }
        void OnDisable() => Deactivate();
        void OnDestroy() { if(enabled) Deactivate(); }

        public virtual void Update()
        {
            if(!_pulse) return;
            SetMaterialsColor(Color.Lerp(_startColor, GetGoalColor(), Mathf.PingPong(_time += Time.deltaTime, 1)));
        }

        public void Activate() => _pulse = true;
        public void Deactivate()
        {
            _pulse = false;
            _time = 0;
            SetMaterialsColor(_startColor);
        }

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