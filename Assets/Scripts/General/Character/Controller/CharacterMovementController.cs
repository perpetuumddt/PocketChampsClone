using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;
    private Vector3 _currentVelocity;
    public virtual void DoMove(params object[] param)
    {
        SetVelocity((Vector3)param[0]);
        Debug.Log(_currentVelocity);
    }

    private void SetVelocity(Vector3 velocity)
    {
        _currentVelocity.Set(velocity.x, velocity.y, velocity.z);
        _rb.velocity = _currentVelocity;
    }
}
