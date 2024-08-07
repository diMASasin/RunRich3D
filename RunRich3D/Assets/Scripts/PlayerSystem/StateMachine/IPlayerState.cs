namespace PlayerSystem.StateMachine
{
    public interface IPlayerState : ITickablePlayerState
    {
        void Enter();
        void Exit();
    }

    public interface ITickablePlayerState
    {
        void Tick();
    }
}