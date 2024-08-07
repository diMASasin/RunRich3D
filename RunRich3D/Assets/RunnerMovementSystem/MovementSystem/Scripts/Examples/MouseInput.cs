using System;
using UnityEngine;

namespace RunnerMovementSystem.Examples
{
    public class MouseInput : MonoBehaviour, IInput
    {
        [SerializeField] private MovementSystem _roadMovement;
        [SerializeField] private float _sensitivity = 0.01f;

        private Vector3 _mousePosition;
        private float _saveOffset;

        public bool IsMoved { get; private set; }

        public event Action MovementStarted;

        private void OnEnable()
        {
            _roadMovement.PathChanged += OnPathChanged;
        }

        private void OnDisable()
        {
            _roadMovement.PathChanged -= OnPathChanged;
        }

        private void OnPathChanged(PathSegment _)
        {
            _saveOffset = _roadMovement.Offset;
            _mousePosition = Input.mousePosition;
        }

        private void Update()
        {
            // TryStartMove();
            //
            // TryChangePosition();
            //
            // TryStopMove();
            //
            // if(IsMoved)
            //     _roadMovement.MoveForward();
        }

        public void TryStartMove()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _saveOffset = _roadMovement.Offset;
                _mousePosition = Input.mousePosition;
                IsMoved = true;
                
                MovementStarted?.Invoke();
            }
        }

        public void TryChangePosition()
        {
            if (Input.GetMouseButton(0))
            {
                var offset = Input.mousePosition - _mousePosition;
                _roadMovement.SetOffset(_saveOffset + offset.x * _sensitivity);
            }
        }

        public void TryStopMove()
        {
            if (Input.GetMouseButtonUp(0))
            {
                // IsMoved = false;
            }
        }
    }

    public interface IInput
    {
        event Action MovementStarted;
        
        void TryStartMove();
        void TryChangePosition();
        public void TryStopMove();
    }
}