using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem.StateMachine
{
    public class DebugGameStateMachine : GameStateMachine
    {
        public DebugGameStateMachine(List<IGameState> states) : base(states)
        {
        }
        
        public override void SwitchState<T>()
        {
            base.SwitchState<T>();
            Debug.Log($"{typeof(T).Name}");
        }
    }
}