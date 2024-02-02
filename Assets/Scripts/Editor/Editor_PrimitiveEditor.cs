#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using TopdownManipulation.Behaviours;
using TopdownManipulation.Primitives;
using UnityEditor;
using UnityEngine;

namespace TopdownManipulation.EditorExtensions
{
    [CustomEditor(typeof(Primitive), true)]
    public class Editor_PrimitiveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUI.BeginChangeCheck();
            var primitive = (target as Primitive);
            GUILayout.Label($"Primitive - {primitive.PrimitiveName}", EditorStyles.boldLabel);
            GUILayout.Space(10);
            GUILayout.Label($"Behaviours:", EditorStyles.boldLabel);
            var behaviours = primitive.GetBehaviours<BehaviourBase>();
            if(behaviours.Length == 0) GUILayout.Label("None");
            foreach (var behaviour in behaviours)
            {
                GUILayout.Label(behaviour.BehaviourName);
            }
            if(EditorGUI.EndChangeCheck()) Editor_Utilities.GUI_ApplyChanges(target);
        }
    }
}
#endif
