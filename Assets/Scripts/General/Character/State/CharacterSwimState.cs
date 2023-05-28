using StateMachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterSwimState : State<CharacterController>
{
    private string _animParameter = "isSwim";
    private Vector3 velocity = new Vector3(0f, 0f, 4f);

    public CharacterSwimState(CharacterController data, StateMachine<CharacterController> machine) : base(data, machine)
    {
    }

    public override void Initialize(params object[] param)
    {
        base.Initialize(param);
        StateMachine.CurrentState.Data.TriggerController.OnRun += SwitchStateRun;
        StateMachine.CurrentState.Data.TriggerController.OnClimb += SwitchStateClimb;
        ChangePos(new(0, -2, 0));
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
        StateMachine.CurrentState.Data.TriggerController.OnRun -= SwitchStateRun;
        StateMachine.CurrentState.Data.TriggerController.OnClimb -= SwitchStateClimb;
    }

    public void SwitchStateRun()
    {
        StopExecution();
        StateMachine.CurrentState = new CharacterRunState(StateMachine.CurrentState.Data, StateMachine);
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
