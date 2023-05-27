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
        }

        public override void Execute()
        {
            base.Execute();
            
            StateMachine.CurrentState.Data.AnimationController.SetActiveBoolAnim(_animParameter, true);

            
        }

        public override void StopExecution()
        {
            base.StopExecution();

            StateMachine.CurrentState.Data.AnimationController.SetActiveBoolAnim(_animParameter, false);
        }
    }
}

