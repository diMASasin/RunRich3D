using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RunnerMovementSystem.Examples
{
    public class MouseInput2 : MonoBehaviour
    {
        [SerializeField] private MovementSystem _roadMovement;
        [SerializeField] private float _sensitivity = 0.01f;
        [SerializeField] private RotationMovement _rotationObject;
        // [SerializeField] private MainMenuScreen _mainMenuScreen;

        private Vector3 _mouseDownPosition;
        private bool _isLockOffset;

        private Vector3 _mousePosition;
        private float _saveOffset;
        private bool _firstTouch = false;
        private bool _mainMenuTouched = false;

        public bool IsMoved { get; private set; }

        public bool FirstTouch => _firstTouch;
        
        public event UnityAction Touched;

        private void OnEnable()
        {
            _roadMovement.PathChanged += OnPathChanged;
            // _mainMenuScreen.Touched += OnMainMenuTouched;
        }

        private void OnDisable()
        {
            _roadMovement.PathChanged -= OnPathChanged;
            // _mainMenuScreen.Touched -= OnMainMenuTouched;
        }

        private void OnPathChanged(PathSegment _)
        {
            _saveOffset = _roadMovement.Offset;
            _mousePosition = Input.mousePosition;
        }

        private void OnMainMenuTouched()
        {
            _mainMenuTouched = true;
        }

        private void Update()
        {
            // if (!_mainMenuTouched)
            //     return;

            if (Input.GetMouseButtonDown(0))
            {
                if (_firstTouch == false)
                {
                    _firstTouch = true;
                    Touched?.Invoke();
                }

                _saveOffset = _roadMovement.Offset;
                _mousePosition = Input.mousePosition;
                _mouseDownPosition = Input.mousePosition;
                IsMoved = true;
            }

            if(_firstTouch == false)
                return;
            
            if (Input.GetMouseButton(0))
            {
                var offset = Input.mousePosition - _mousePosition;
                _roadMovement.SetOffset(_saveOffset + offset.x * _sensitivity);
            }

            var rotationOffset = Input.mousePosition - _mouseDownPosition;
            _roadMovement.MoveForward();
            _rotationObject.TryRotateTowardsDirection(rotationOffset);

            if (Input.GetMouseButtonUp(0))
            {
                IsMoved = false;
            }
        }
    }
}