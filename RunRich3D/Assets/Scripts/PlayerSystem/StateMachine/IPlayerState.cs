namespace PlayerSystem.StateMachine
{
    public interface IGameState : ITickablePlayerState
    {
        void Enter();
        void Exit();
    }

    public interface ITickablePlayerState
    {
        void Tick();
    }
}