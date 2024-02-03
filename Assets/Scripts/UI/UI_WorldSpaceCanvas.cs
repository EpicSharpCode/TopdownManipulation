using System;
using System.Collections;
using System.Collections.Generic;
using TopdownManipulation;
using TopdownManipulation.Primitives;
using UnityEngine;

public abstract class UI_WorldSpaceCanvas : MonoBehaviour
{
    protected Primitive _primitive;
    
    [SerializeField] float _secondsToFade = 0.35f;
    float _currentSeconds;
    
    bool _canvasState;
    CanvasGroup _canvasGroup;

    public virtual void Awake()
    {
        _canvasGroup = GetComponentInChildren<CanvasGroup>() ?? 
                       gameObject.GetComponentInChildren<Canvas>().gameObject.AddComponent<CanvasGroup>();
        Show();
        _canvasGroup.alpha = 0;
    }

    public virtual void Setup(Primitive p)
    {
        _primitive = p;
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

    public virtual void CloseButton() => Hide();

    void Update()
    {
        _currentSeconds += Time.deltaTime;
        UpdateCanvasGroupState(_canvasState);
    }
    void UpdateCanvasGroupState(bool state)
    {
        float qt = _currentSeconds / _secondsToFade;
        if (qt >= 1) qt = 1;
        _canvasGroup.alpha = state ? qt : 1 - qt;
        _canvasGroup.interactable = state;
        _canvasGroup.blocksRaycasts = state;
        if(!state && _canvasGroup.alpha <= 0) Destroy(gameObject);
    }
}
