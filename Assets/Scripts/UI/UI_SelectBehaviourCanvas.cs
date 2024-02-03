using System;
using TopdownManipulation.Behaviours;
using TopdownManipulation.Primitives;
using UnityEngine;
using UnityEngine.UI;

namespace TopdownManipulation.UI
{
    public class UI_SelectBehaviourCanvas : UI_WorldSpaceCanvas
    {
        [Header("Select Behaviour Canvas")]
        [SerializeField] Button _greenColorButton;
        [SerializeField] Button _redPulseButton;
        [SerializeField] Button _upMoveButton;
        [SerializeField] Color _activeButtonColor = Color.white;
        [SerializeField] Color _inactiveButtonColor = Color.white;

        public override void Awake()
        {
            base.Awake();
            SetupButtons();
        }
        public override void Setup(Primitive p)
        {
            base.Setup(p);
            CheckButtons();
        }

        public void SetupButtons()
        {
            AddBehaviourButton<RedPulseColorBehaviour>(_redPulseButton);
            AddBehaviourButton<GreenColorMaterialBehaviour>(_greenColorButton);
            AddBehaviourButton<UpMovementBehaviour>(_upMoveButton);
        }
        public void CheckButtons()
        {
            CheckButtonState<RedPulseColorBehaviour>(_redPulseButton);
            CheckButtonState<GreenColorMaterialBehaviour>(_greenColorButton);
            CheckButtonState<UpMovementBehaviour>(_upMoveButton);
        }

        void CheckButtonState<T>(Button button) where T : BehaviourBase
        {
            button.GetComponent<Image>().color =  _primitive.GetBehaviours<T>().Length > 0 
                ? _activeButtonColor : _inactiveButtonColor;
        }

        public void AddBehaviourButton<T>(Button button) where T : BehaviourBase
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener( delegate { ClickBehaviourButton<T>(); });
        }

        public void ClickBehaviourButton<T>() where T : BehaviourBase
        {
            if(_primitive.GetBehaviours<T>().Length > 0) _primitive.RemoveBehaviours<T>();
            else _primitive.AddBehaviour<T>();
            Invoke("CheckButtons", Time.deltaTime);
        }
    }
}