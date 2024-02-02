using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopdownManipulation.Behaviours
{
    public interface IBehaviour
    {
        void Activate();
        void Deactivate();
    }
}
