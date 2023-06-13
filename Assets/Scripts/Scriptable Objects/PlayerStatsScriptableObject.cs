using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsData", menuName = "Data/Player Data/New Player Stats Data")]
public class PlayerStatsScriptableObject : ScriptableObject
{
    [SerializeField]
    private float _runMinSpeed;
    public float RunMinSpeed => _runMinSpeed;

    [SerializeField]
    private float _runMidSpeed;
    public float RunMidSpeed => _runMidSpeed;

    [SerializeField]
    private float _runMaxSpeed;
    public float RunMaxSpeed => _runMaxSpeed;

    [SerializeField]
    private float _climbSpeed;
    public float ClimbSpeed => _climbSpeed;

    [SerializeField]
    private float _swimMaxSpeed;
    public float SwimMaxSpeed => _swimMaxSpeed;

    [SerializeField]
    private float _swimMidSpeed;
    public float SwimMidSpeed => _swimMidSpeed;

    [SerializeField]
    private float _swimMinSpeed;
    public float SwimMinSpeed => _swimMinSpeed;
}
