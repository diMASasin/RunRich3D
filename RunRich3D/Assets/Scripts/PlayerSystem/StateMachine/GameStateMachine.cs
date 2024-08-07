using System.Collections.Generic;
using System.Linq;
using PlayerSystem.StateMachine.States;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;

namespace PlayerSystem.StateMachine
{
    public class GameStateMachine : IPlayerStateSwitcher
    {
        private readonly List<IGameState> _states;
        private IGameState _currentState;

        public GameStateMachine(List<IGameState> states)
        {
            _states = states;
        }

        public virtual void SwitchState<T>() where T : IGameState
        {
            IGameState state = _states.FirstOrDefault(state => state is T);

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Tick() => _currentState.Tick();
    }
}