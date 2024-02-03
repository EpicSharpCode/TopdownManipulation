using System;
using System.Collections;
using System.Collections.Generic;
using TopdownManipulation.Primitives;
using UnityEngine;
using UnityEngine.Serialization;

public class UI_Controller : MonoBehaviour
{
    static UI_Controller _instance;
    
    [FormerlySerializedAs("_worldSpaceCanvasPrefab")]
    [SerializeField] UI_WorldSpaceCanvas _selectBehaviourCanvasPrefab;
    static UI_WorldSpaceCanvas _worldSpaceCanvasInstance;

    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static UI_WorldSpaceCanvas ShowWorldSpaceCanvas(Primitive p)
    {
        _worldSpaceCanvasInstance = Instantiate(_instance._selectBehaviourCanvasPrefab);
        _worldSpaceCanvasInstance.transform.position = p.transform.position;
        _worldSpaceCanvasInstance?.Setup(p);
        _worldSpaceCanvasInstance?.Show();
        return _worldSpaceCanvasInstance;
    }
    public static void HideActiveWorldSpaceCanvas() => _worldSpaceCanvasInstance?.Hide();

}
