using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class CharacterDanceState : State<CharacterController>
    {
        private string _animParameter = "isDance";
        private Vector3 velocity = new(0f, 0f, 0f);
        public CharacterDanceState(CharacterController data, StateMachine<CharacterController> machine) : base(data, machine)
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
            StateMachine.CurrentState.Data.MovementController.DoMove(velocity);
        }

        public override void StopExecution()
        {
            base.StopExecution();
            StateMachine.CurrentState.Data.AnimationController.SetActiveBoolAnim(_animParameter, false);
        }
    }

}
