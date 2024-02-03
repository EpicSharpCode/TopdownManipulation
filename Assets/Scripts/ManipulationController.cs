using System;
using TopdownManipulation.Primitives;
using UnityEngine;

namespace TopdownManipulation
{
    public class ManipulationController : MonoBehaviour
    {
        static ManipulationController _instance;
        
        static Primitive _selectedPrimitive;
        public static Primitive SelectedPrimitive => _selectedPrimitive;

        void Awake()
        {
            _instance = this;
        }

        public static void Select(Primitive p)
        {
            if (_selectedPrimitive == p) return;
            UI_Controller.HideActiveWorldSpaceCanvas();
            _selectedPrimitive?.DeactivateAllBehaviours();
            
            _selectedPrimitive = p;
            _selectedPrimitive.ActivateAllBehaviours();
            CameraControl.SelectGoal(p.transform);
            UI_Controller.ShowWorldSpaceCanvas(p);
        }
        public static void Deselect()
        {
            _selectedPrimitive?.DeactivateAllBehaviours();
            _selectedPrimitive = null;
            CameraControl.SelectGoal(null);
            UI_Controller.HideActiveWorldSpaceCanvas();
        }
    }
}