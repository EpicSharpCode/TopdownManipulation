using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopdownManipulation
{
    [RequireComponent(typeof(Camera))]
    public class CameraControl : MonoBehaviour
    {
        static CameraControl _instance;
        [SerializeField] Vector3 _cameraOffset;
        [SerializeField] float _secondsToLerp = 3;
        
        float _currentSeconds;
        Vector3 _standardPosition;
        Vector3 _goal;
        
        void Awake()
        {
            _instance = this;
            _goal = Vector3.zero;
            _standardPosition = transform.position;
            _currentSeconds = 0;
        }

        void Update()
        {
            FollowGoal();
        }

        void FollowGoal()
        {
            _currentSeconds += Time.deltaTime;
            float t = _currentSeconds / _secondsToLerp;
            if (t > 1) t = 1;
            
            if (_goal == Vector3.zero)
            {
                transform.position = Vector3.Lerp(transform.position, _standardPosition, t);
                return;
            }
            transform.position = Vector3.Lerp(transform.position, _goal + _cameraOffset, t);
        }

        public static void SelectGoal(Vector3 goal)
        {
            _instance._currentSeconds = 0;
            _instance._goal = goal;
        }
        public static void SelectGoal(Transform goalTransform)
        {
            if(goalTransform == null) SelectGoal(Vector3.zero);
            else SelectGoal(goalTransform.position);
        }
    }
}
