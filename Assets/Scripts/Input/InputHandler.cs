using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public event Action OnTouch;
    public event Action OnSwipe;

    public bool TouchInput { get; protected set; }

    protected void InvokeOnTouch()
    {
        OnTouch?.Invoke();
    }

    protected void InvokeOnSwipe()
    {
        OnSwipe?.Invoke();
    }

    
}
