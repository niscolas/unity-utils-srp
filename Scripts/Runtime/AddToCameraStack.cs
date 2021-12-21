﻿using niscolas.UnityExtensions;
using niscolas.UnityUtils.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityUtils;

namespace niscolas.UnityUtils.SRP
{
    public class AddToCameraStack : MonoBehaviour
    {
        [SerializeField]
        private Camera _cameraToAdd;

        [SerializeField]
        private MonoCallbackType _addMoment = MonoCallbackType.Awake;

        private GameObject _gameObject;

        private void Awake()
        {
            _gameObject = gameObject;
            _gameObject.IfUnityNullGetComponent(ref _cameraToAdd);
            MonoLifecycleHooksManager.AutoTrigger(_gameObject, Add, _addMoment);
        }

        private void Add()
        {
            Camera.main.GetUniversalAdditionalCameraData().cameraStack.Add(_cameraToAdd);
        }
    }
}