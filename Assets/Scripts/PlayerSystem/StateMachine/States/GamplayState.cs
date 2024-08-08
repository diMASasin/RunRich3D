using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UI;

namespace PlayerSystem.StateMachine.States
{
    public class GamplayState : IGameState, ITickablePlayerState
    {
        private readonly PlayerAnimations _animations;
        private IPlayerStateSwitcher _stateSwitcher;
        private UiRoot _uiRoot;
        private Player _player;

        public GamplayState(IPlayerStateSwitcher stateSwitcher, Player player, UiRoot uiRoot)
        {
            _player = player;
            _uiRoot = uiRoot;
            _stateSwitcher = stateSwitcher;
        }

        public void Enter()
        {
            _uiRoot.StartCanvas.gameObject.SetActive(false);
            _uiRoot.GameplayCanvas.gameObject.SetActive(true);
        }

        public void Exit()
        {
        }

        public void Tick()
        {
        }
    }
}