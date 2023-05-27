using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClimbState : State<CharacterController> 
{
    private string _animParameter = "isClimb";
    private Vector3 velocity = new Vector3(0f, 4f, 0f);

    public CharacterClimbState(CharacterController data, StateMachine<CharacterController> machine) : base(data, machine)
    {
    }

    public override void Initialize(params object[] param)
    {
        base.Initialize(param);
        StateMachine.CurrentState.Data.TriggerController.OnFinish += SwitchStateDance;
        StateMachine.CurrentState.Data.TriggerController.OnRun += SwitchStateRun;
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
        StateMachine.CurrentState.Data.TriggerController.OnRun -= SwitchStateRun;
    }

    private void SwitchStateIdle()
    {
        StopExecution();
        StateMachine.CurrentState = new CharacterIdleState(StateMachine.CurrentState.Data, StateMachine);
        StateMachine.CurrentState.Initialize();
    }

    public void SwitchStateDance()
    {
        StopExecution();
        StateMachine.CurrentState = new CharacterDanceState(StateMachine.CurrentState.Data, StateMachine);
        StateMachine.CurrentState.Initialize();
        StateMachine.CurrentState.Execute();
    }

    public void SwitchStateRun()
    {
        StopExecution();
        StateMachine.CurrentState = new CharacterRunState(StateMachine.CurrentState.Data, StateMachine);
        StateMachine.CurrentState.Initialize();
        StateMachine.CurrentState.Execute();
    }

    private void Movement(Vector3 velocity)
    {
        StateMachine.CurrentState.Data.MovementController.DoMove(velocity);
    }
}
