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
        if(other.CompareTag("Finish"))
        {
            InvokeOnFinish();
        }
        else if(other.CompareTag("ClimbingArea"))
        {
            InvokeOnClimbing();
        }
        else if(other.CompareTag("RunningArea"))
        {
            InvokeOnRunning();
        }
        else if(other.CompareTag("SwimmingArea"))//Сделать отдельными переменными
        {
            InvokeOnSwimming();
        } //TODO: переделать на switch
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
