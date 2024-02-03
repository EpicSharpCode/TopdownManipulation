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

        [SerializeField] LayerMask layerMask;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(IsClickOnUI()) return;
                var primitive = TryRaycast<Primitive>();
                if (primitive != null) ManipulationController.Select(primitive);
                else ManipulationController.Deselect();
            }
        }

        public T TryRaycast<T>() where T : Primitive
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitState = Physics.Raycast(ray, out var raycastHit, 100, layerMask);
            if (hitState) return raycastHit.collider.GetComponent<T>();
            
            return null;
        }
        
        bool IsClickOnUI() => UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }
}
