using System;
using UnityEngine;
using Zenject;

namespace Logic.Movement
{
    public class PlayerHeadRotation : MonoBehaviour
    {
        [SerializeField] private float _xSensitivity;
        [SerializeField] private float _ySensitivity;
        [SerializeField] private Transform _orientation;

        private const float XRotationClamp = 90;
        private InputActionMaps _inputActionMaps;
        private float _xRotation;
        private float _yRotation;
        private Vector2 _mouseDelta;

        [Inject]
        private void Construct(InputActionMaps inputActionMaps)
        {
            _inputActionMaps = inputActionMaps;
        }
        
        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }


        private void LateUpdate()
        {
            _mouseDelta = _inputActionMaps.Map.CameraDelta.ReadValue<Vector2>();
            CameraMove();
        }

        private void CameraMove()
        {
            float mouseX = _mouseDelta.x * Time.deltaTime * _xSensitivity;
            float mouseY = _mouseDelta.y * Time.deltaTime * _ySensitivity;

            _yRotation += mouseX;
            _xRotation -= mouseY;

            _xRotation = Mathf.Clamp(_xRotation, -XRotationClamp, XRotationClamp);
            SetRotation(_xRotation, _yRotation);
        }

        private void SetRotation(float xRotation, float yRotation)
        {
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            _orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}