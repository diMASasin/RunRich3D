using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;

namespace PlayerSystem.StateMachine
{
    public class DebugPlayerStateMachine : PlayerStateMachine
    {
        public DebugPlayerStateMachine(PlayerAnimations playerAnimations, IInput mouseInput,
            MovementSystem movementSystem) : base(playerAnimations, mouseInput, movementSystem)
        {
        }

        public override void SwitchState<T>()
        {
            base.SwitchState<T>();
            Debug.Log($"{typeof(T).Name}");
        }
    }
}