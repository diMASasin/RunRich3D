using System.Collections.Generic;
using System.Linq;
using PlayerSystem.StateMachine.States;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;

namespace PlayerSystem.StateMachine
{
    public class PlayerStateMachine : IPlayerStateSwitcher
    {
        private readonly List<IPlayerState> _states;
        private IPlayerState _currentState;

        public PlayerStateMachine(PlayerAnimations playerAnimations, IInput mouseInput, MovementSystem movementSystem)
        {
            _states = new List<IPlayerState>()
            {
                new Idle(this, playerAnimations, mouseInput),
                new Run(this, playerAnimations, mouseInput, movementSystem)
            };
        }

        public virtual void SwitchState<T>() where T : IPlayerState
        {
            IPlayerState state = _states.FirstOrDefault(state => state is T);

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Tick() => _currentState.Tick();
    }
}