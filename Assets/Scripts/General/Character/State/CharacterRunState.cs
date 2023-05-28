using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace StateMachine
{
    public class CharacterRunState : State<CharacterController>
    {
        private string _animParameter = "isRun";
        private Vector3 velocity = new Vector3(0f, 0f, 7f);

        public CharacterRunState(CharacterController data, StateMachine<CharacterController> machine) : base(data, machine)
        {
        }

        public override void Initialize(params object[] param)
        {
            base.Initialize(param);
            StateMachine.CurrentState.Data.TriggerController.OnFinish += SwitchStateDance;
            StateMachine.CurrentState.Data.TriggerController.OnClimb += SwitchStateClimb;
            StateMachine.CurrentState.Data.TriggerController.OnSwim += SwitchStateSwim;
        }

        public override void Execute()
        {
            base.Execute();
            StateMachine.CurrentState.Data.AnimationController.SetActiveBoolAnim(_animParameter, true);
            
            Movement(velocity);
        }

        public override void StopExecution()
        {
            base.StopExecution();
            StateMachine.CurrentState.Data.AnimationController.SetActiveBoolAnim(_animParameter, false);
            StateMachine.CurrentState.Data.TriggerController.OnFinish -= SwitchStateDance;
            StateMachine.CurrentState.Data.TriggerController.OnClimb -= SwitchStateClimb;
            StateMachine.CurrentState.Data.TriggerController.OnSwim -= SwitchStateSwim;
        }

        public void SwitchStateDance()
        {
            StopExecution();
            StateMachine.CurrentState = new CharacterDanceState(StateMachine.CurrentState.Data,StateMachine);
            StateMachine.CurrentState.Initialize();
            StateMachine.CurrentState.Execute();
        }

        public void SwitchStateClimb()
        {
            StopExecution();
            StateMachine.CurrentState = new CharacterClimbState(StateMachine.CurrentState.Data, StateMachine);
            StateMachine.CurrentState.Initialize();
            StateMachine.CurrentState.Execute();
        }

        public void SwitchStateSwim()
        {
            StopExecution();
            StateMachine.CurrentState = new CharacterSwimState(StateMachine.CurrentState.Data, StateMachine);
            StateMachine.CurrentState.Initialize();
            StateMachine.CurrentState.Execute();
        }

        private void Movement(Vector3 velocity)
        {
            StateMachine.CurrentState.Data.MovementController.DoMove(velocity);
        }

        private async void ChangePos(Vector3 dir)
        {
            StateMachine.CurrentState.Data.MovementController.DoMove(dir);
            await Task.Delay(1000);
        }
    }
}

