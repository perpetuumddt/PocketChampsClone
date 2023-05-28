using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class CharacterIdleState : State<CharacterController>
    {
        private string _animParameter = "isIdle";
        public CharacterIdleState(CharacterController data, StateMachine<CharacterController> machine) : base(data, machine)
        {
        }

        public override void Initialize(params object[] param)
        {
            base.Initialize(param);
            StateMachine.CurrentState.Data.TriggerController.OnRun += SwitchStateRun;
        }

        public override void Execute()
        {
            base.Execute();
            
            StateMachine.CurrentState.Data.AnimationController.SetActiveBoolAnim(_animParameter, true);

            
        }

        public override void StopExecution()
        {
            base.StopExecution();
            StateMachine.CurrentState.Data.TriggerController.OnRun -= SwitchStateRun;
            StateMachine.CurrentState.Data.AnimationController.SetActiveBoolAnim(_animParameter, false);
        }

        public void SwitchStateRun()
        {
            StopExecution();
            StateMachine.CurrentState = new CharacterRunState(StateMachine.CurrentState.Data, StateMachine);
            StateMachine.CurrentState.Initialize();
            StateMachine.CurrentState.Execute();
        }
    }
}

