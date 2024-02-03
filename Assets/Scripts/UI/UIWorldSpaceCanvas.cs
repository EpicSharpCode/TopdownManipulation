using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWorldSpaceCanvas : MonoBehaviour
{
    [SerializeField] float _secondsToFade;
    float _currentSeconds;
    
    bool _canvasState;
    CanvasGroup _canvasGroup;

    public void Awake()
    {
        _canvasGroup = GetComponentInChildren<CanvasGroup>() ?? 
                       gameObject.GetComponentInChildren<Canvas>().gameObject.AddComponent<CanvasGroup>();
        Show();
        _canvasGroup.alpha = 0;
    }

    public void Show()
    {
        _currentSeconds = 0;
        _canvasState = true;
    }
    public void Hide()
    {
        _currentSeconds = 0;
        _canvasState = false;
    }

    void Update()
    {
        _currentSeconds += Time.deltaTime;
        UpdateCanvasState(_canvasState);
    }
    void UpdateCanvasState(bool state)
    {
        float qt = _currentSeconds / _secondsToFade;
        if (qt >= 1) qt = 1;
        _canvasGroup.alpha = state ? qt : 1 - qt;
        _canvasGroup.interactable = state;
        _canvasGroup.blocksRaycasts = state;
        if(!state && _canvasGroup.alpha <= 0) Destroy(gameObject);
    }
}
