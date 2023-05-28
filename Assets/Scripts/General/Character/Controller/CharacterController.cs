using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterAnimationController _animationController;
    public CharacterAnimationController AnimationController => _animationController;

    [SerializeField]
    private CharacterMovementController _movementController;
    public CharacterMovementController MovementController => _movementController;

    [SerializeField]
    private CharacterInputHandler _inputHandler;
    public CharacterInputHandler InputHandler => _inputHandler;

    [SerializeField]
    private CharacterTriggerController _triggerController;
    public CharacterTriggerController TriggerController => _triggerController;

    private StateMachine<CharacterController> _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine<CharacterController>();
        _stateMachine.CurrentState = new CharacterIdleState(this,_stateMachine);
        _stateMachine.CurrentState.Initialize();
        _stateMachine.CurrentState.Execute();
    }
}
