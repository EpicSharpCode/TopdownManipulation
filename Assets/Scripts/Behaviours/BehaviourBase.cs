using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TopdownManipulation.Primitives;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    [RequireComponent(typeof(Primitive))]
    public abstract class BehaviourBase : MonoBehaviour
    {
        protected Primitive _thisPrimitive;
        public abstract string BehaviourName { get; }
        
        void Awake()
        {
            _thisPrimitive = GetComponent<Primitive>();
            if(_thisPrimitive == null) Destroy(this);
        }
    }

}