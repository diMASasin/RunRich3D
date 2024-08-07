using PlayerSystem.StateMachine;
using PlayerSystem.StateMachine.States;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerAnimations _animations;
        [SerializeField] private MouseInput _mouseInput;
        [SerializeField] private MovementSystem _movementSystem;
        
        private PlayerStateMachine _stateMachine; 
        
        private void Start()
        {
            _stateMachine = new DebugPlayerStateMachine(_animations, _mouseInput, _movementSystem);
            _stateMachine.SwitchState<Idle>();
        }

        private void Update()
        {
            _stateMachine.Tick();
        }
    }
}