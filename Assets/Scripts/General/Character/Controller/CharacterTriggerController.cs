using StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerController : MonoBehaviour
{
    public delegate void PlayerHandler();

    public event PlayerHandler OnFinish;
    public event PlayerHandler OnClimb;
    public event PlayerHandler OnRun;
    public event PlayerHandler OnSwim;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Finish":
                InvokeOnFinish();
                break;
            case "ClimbingArea":
                InvokeOnClimbing(); 
                break;
            case "RunningArea":
                InvokeOnRunning(); 
                break;
            case "SwimmingArea":
                InvokeOnSwimming();
                break;
        }
    }

    private void InvokeOnFinish()
    {
        OnFinish?.Invoke();
    }
    private void InvokeOnClimbing()
    {
        OnClimb?.Invoke();
    }
    private void InvokeOnRunning()
    {
        OnRun?.Invoke();
    }
    private void InvokeOnSwimming()
    {
        OnSwim?.Invoke();
    }
}
