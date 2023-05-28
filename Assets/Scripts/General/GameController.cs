using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private DirectionalLight _light;
    private void Awake()
    {
        _light.orientation = Quaternion.Euler(0, 0, 0);
    }
}
