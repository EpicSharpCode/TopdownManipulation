#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using TopdownManipulation.Behaviours;
using TopdownManipulation.Primitives;
using UnityEditor;
using UnityEngine;

namespace TopdownManipulation.EditorExtensions
{
    [CustomEditor(typeof(BehaviourBase), true)]
    public class Editor_BehaviourEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUI.BeginChangeCheck();
            var behaviour = (target as BehaviourBase);
            GUILayout.Space(10);
            GUILayout.Label($"Behaviour - {behaviour.BehaviourName}", EditorStyles.boldLabel);
            if(EditorGUI.EndChangeCheck()) Editor_Utilities.GUI_ApplyChanges(target);
        }
    }
}
#endif