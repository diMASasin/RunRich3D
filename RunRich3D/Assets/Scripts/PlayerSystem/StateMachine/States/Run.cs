using RunnerMovementSystem;
using RunnerMovementSystem.Examples;

namespace PlayerSystem.StateMachine.States
{
    public class Run : IPlayerState, ITickablePlayerState
    {
        private readonly PlayerAnimations _animations;
        private IPlayerStateSwitcher _stateSwitcher;
        private readonly IInput _mouseInput;
        private MovementSystem _movementSystem;

        public Run(IPlayerStateSwitcher stateSwitcher, PlayerAnimations animations, IInput mouseInput,
            MovementSystem movementSystem)
        {
            _movementSystem = movementSystem;
            _mouseInput = mouseInput;
            _stateSwitcher = stateSwitcher;
            _animations = animations;
        }

        public void Enter()
        {
            _animations.PlayAnimation(PlayerAnimations.Walk);
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            _mouseInput.TryChangePosition();
            
            _movementSystem.MoveForward();
        }
    }
}