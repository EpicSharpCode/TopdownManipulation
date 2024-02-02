using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public interface IBehaviourHandler
    {
        public T AddBehaviour<T>() where T : BehaviourBase;
        public void RemoveBehaviour<T>(T t) where T : BehaviourBase;
        public void RemoveBehaviours<T>(T exception, bool silently = true) where T : BehaviourBase;
        public BehaviourBase[] GetBehaviours<T>() where T : BehaviourBase;
    }
}
