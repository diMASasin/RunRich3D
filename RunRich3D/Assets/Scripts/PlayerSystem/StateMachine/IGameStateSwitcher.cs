namespace PlayerSystem.StateMachine
{
    public interface IPlayerStateSwitcher
    {
        void SwitchState<T>() where T : IPlayerState;
    }
}