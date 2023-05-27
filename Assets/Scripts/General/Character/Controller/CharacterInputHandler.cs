using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputHandler : InputHandler
{
    private PocketChampInputActions inputActions;
    private void Awake()
    {
        inputActions = new PocketChampInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Gameplay.TouchInput.started += OnTouchInput;
    }

    private void OnDisable()
    {
        inputActions.Disable();

        inputActions.Gameplay.TouchInput.started -= OnTouchInput;
    }

    public void OnTouchInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InvokeOnTouch();
        }
    }
}
