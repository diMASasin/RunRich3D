using RunnerMovementSystem.Examples;
using UI;

namespace PlayerSystem.StateMachine.States
{
    public class GameStartState : IGameState, ITickablePlayerState
    {
        private readonly IPlayerStateSwitcher _stateSwitcher;
        private IInput _input;

        public GameStartState(IPlayerStateSwitcher stateSwitcher, UiRoot uiRoot, IInput input)
        {
            _input = input;
            _stateSwitcher = stateSwitcher;
        }

        public void Enter()
        {
            _input.MovementStarted += OnMovementStarted;
        }

        public void Exit()
        {
            _input.MovementStarted -= OnMovementStarted;
        }

        private void OnMovementStarted()
        {
            _stateSwitcher.SwitchState<GamplayState>();
        }

        public void Tick()
        {
                
        }
    }
}