using RunnerMovementSystem.Examples;

namespace PlayerSystem.StateMachine.States
{
    public class Idle : IPlayerState, ITickablePlayerState
    {
        private PlayerAnimations _animations;
        private readonly IInput _mouseInput;
        private readonly IPlayerStateSwitcher _stateSwitcher;

        public Idle(IPlayerStateSwitcher stateSwitcher, PlayerAnimations animations, IInput mouseInput)
        {
            _stateSwitcher = stateSwitcher;
            _mouseInput = mouseInput;
            _animations = animations;
        }

        public void Enter()
        {
            _mouseInput.MovementStarted += OnMovementStarted;
        }

        public void Exit()
        {
            _mouseInput.MovementStarted -= OnMovementStarted;
        }

        private void OnMovementStarted()
        {
            _stateSwitcher.SwitchState<Run>();
        }

        public void Tick()
        {
            _mouseInput.TryStartMove();
        }
    }
}