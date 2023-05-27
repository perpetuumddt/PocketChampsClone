using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    public virtual void SetActiveBoolAnim(string parameter, bool value)
    {
        _animator.SetBool(parameter, value);
    }
}
