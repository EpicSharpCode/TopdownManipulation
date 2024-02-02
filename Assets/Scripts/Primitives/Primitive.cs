using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TopdownManipulation.Behaviours;
using UnityEngine;

namespace TopdownManipulation.Primitives
{
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class Primitive : MonoBehaviour, IBehaviourHandler
    {
        MeshRenderer _meshRenderer;
        public MeshRenderer MeshRenderer => _meshRenderer;
        
        public abstract string PrimitiveName { get; }
        void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>() ?? gameObject.AddComponent<MeshRenderer>();
            CreateIndependentMaterial();
        }

        public void CreateIndependentMaterial()
        {
            for (int i = 0; i < _meshRenderer.materials.Length; i++) 
                _meshRenderer.materials[i] = new Material(_meshRenderer.materials[i]);
        }

        public T AddBehaviour<T>() where T : BehaviourBase
        {
            if(gameObject.GetComponents<T>().Length > 0) return null;
            return gameObject.AddComponent<T>();
        }
        public void RemoveBehaviour<T>(T t) where T : BehaviourBase => Destroy(gameObject.GetComponents<T>().ToList().Find(x => x == t));

        public void RemoveBehaviours<T>(T exception = null, bool silently = true) where T : BehaviourBase 
        // silently bool help prevent Deactivate() in Destroy() MonoBehaviour Lifecycle
        {
            var components = gameObject.GetComponents<T>().ToList();
            if(exception != null) components.Remove(exception);
            for (int i = 0; i < components.Count; i++) { components[i].enabled = !silently; Destroy(components[i]); }
        }
    }
}
