using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TopdownManipulation.Behaviours;
using TopdownManipulation.Primitives;
using UnityEngine;

namespace TopdownManipulation
{
    public class RaycastInput : MonoBehaviour
    {
        static Primitive _selectedPrimitive;
        public static Primitive SelectedPrimitive => _selectedPrimitive;

        [SerializeField] LayerMask layerMask;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var primitive = TryRaycast<Primitive>();
                if (primitive != null) Select(primitive);
                else Deselect();
            }
        }

        public T TryRaycast<T>() where T : Primitive
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitState = Physics.Raycast(ray, out var raycastHit, 100, layerMask);
            if (hitState)
            {
                return raycastHit.collider.GetComponent<T>();
            }
            return null;
        }

        public void Select(Primitive p)
        {
            if (_selectedPrimitive == p) return;
            _selectedPrimitive?.DeactivateAllBehaviours();
            _selectedPrimitive = p;
            _selectedPrimitive.ActivateAllBehaviours();
            CameraControl.SelectGoal(p.transform);
        }
        public void Deselect()
        {
            _selectedPrimitive?.DeactivateAllBehaviours();
            _selectedPrimitive = null;
            CameraControl.SelectGoal(null);
        }
    }
}
