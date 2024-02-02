#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace TopdownManipulation.EditorExtensions
{
    public class Editor_Utilities
    {
        public static void GUI_ApplyChanges(Object target)
        {
            if(Application.isPlaying) return;
            EditorUtility.SetDirty(target);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
#endif