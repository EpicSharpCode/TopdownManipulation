using System;
using TopdownManipulation.Primitives;
using UnityEngine;

namespace TopdownManipulation
{
    public class ManipulationController : MonoBehaviour
    {
        static ManipulationController _instance;
        [SerializeField] UIWorldSpaceCanvas _worldSpaceCanvasPrefab;
        static UIWorldSpaceCanvas _worldSpaceCanvasInstance;
        
        static Primitive _selectedPrimitive;
        public static Primitive SelectedPrimitive => _selectedPrimitive;

        void Awake()
        {
            _instance = this;
        }

        public static void Select(Primitive p)
        {
            if (_selectedPrimitive == p) return;
            _worldSpaceCanvasInstance?.Hide();
            _selectedPrimitive?.DeactivateAllBehaviours();
            
            _selectedPrimitive = p;
            _selectedPrimitive.ActivateAllBehaviours();
            CameraControl.SelectGoal(p.transform);

            _worldSpaceCanvasInstance = Instantiate(_instance._worldSpaceCanvasPrefab, _selectedPrimitive.transform);
            _worldSpaceCanvasInstance.Show();
        }
        public static void Deselect()
        {
            _selectedPrimitive?.DeactivateAllBehaviours();
            _selectedPrimitive = null;
            CameraControl.SelectGoal(null);
            _worldSpaceCanvasInstance.Hide();
        }
    }
}