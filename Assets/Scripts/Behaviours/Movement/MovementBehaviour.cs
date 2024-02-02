using System;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public abstract class MovementBehaviour : BehaviourBase, IBehaviour
    {
        public abstract Vector3 MovementVector { get; }

        protected bool _movement;
        float _time;
        Vector3 _startPos;
        
        void OnEnable()
        {
            _thisPrimitive.RemoveBehaviours<MovementBehaviour>(this);
            _startPos = transform.position;
        }
        void OnDisable() => Deactivate();
        void OnDestroy() => Deactivate();

        public virtual void Update()
        {
            if (!_movement) return;
            transform.position = Vector3.Lerp(_startPos, _startPos + MovementVector, Mathf.PingPong(_time += Time.deltaTime, 1));
        }

        public void Activate() => _movement = true;
        public void Deactivate()
        {
            _movement = false;
            _time = 0;
            transform.position = _startPos;
        }
    }
}