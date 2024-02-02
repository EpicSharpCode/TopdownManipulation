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
        [SerializeField] Transform _goal;
        void Awake()
        {
            _instance = this;
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
            
            if (_goal == null)
            {
                transform.position = Vector3.Lerp(transform.position, _standardPosition, t);
                return;
            }
            transform.position = Vector3.Lerp(transform.position, _goal.position + _cameraOffset, t);
        }

        public static void SelectGoal(Transform goal)
        {
            _instance._currentSeconds = 0;
            _instance._goal = goal;
        }
    }
}
