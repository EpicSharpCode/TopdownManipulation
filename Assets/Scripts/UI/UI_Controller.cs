using System;
using System.Collections;
using System.Collections.Generic;
using TopdownManipulation.Primitives;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    static UI_Controller _instance;
    
    [SerializeField] UI_WorldSpaceCanvas _worldSpaceCanvasPrefab;
    static UI_WorldSpaceCanvas _worldSpaceCanvasInstance;

    void Awake()
    {
        _instance = this;
    }

    public static UI_WorldSpaceCanvas ShowWorldSpaceCanvas(Primitive p)
    {
        if (_instance == null) return null;
            
        _worldSpaceCanvasInstance = Instantiate(_instance._worldSpaceCanvasPrefab);
        _worldSpaceCanvasInstance.transform.position = p.transform.position;
        _worldSpaceCanvasInstance?.Setup(p);
        _worldSpaceCanvasInstance?.Show();
        return _worldSpaceCanvasInstance;
    }
    public static void HideActiveWorldSpaceCanvas() => _worldSpaceCanvasInstance?.Hide();

}
