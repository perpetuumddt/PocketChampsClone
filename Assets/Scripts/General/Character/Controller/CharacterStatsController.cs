using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStatsController : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsScriptableObject _playerStats;

    [SerializeField]
    private SliderMinigameController _sliderMinigameController;

    protected float _characterVelocity;

    public event Action<float> OnChangeVelocity;


    private void OnEnable()
    {
        _sliderMinigameController.OnSliderPositionChanged += ChangeRunVelocity;
    }

    private void ChangeRunVelocity(SliderMinigameController.SliderPosition sliderPos)
    {
        switch(sliderPos)
        {
            case SliderMinigameController.SliderPosition.Min:
                _characterVelocity = _playerStats.RunMinSpeed;
                OnChangeVelocity?.Invoke(_playerStats.RunMinSpeed);
                break;
            case SliderMinigameController.SliderPosition.Middle:
                _characterVelocity = _playerStats.RunMidSpeed;
                OnChangeVelocity?.Invoke(_playerStats.RunMidSpeed);
                break;
            case SliderMinigameController.SliderPosition.Max:
                _characterVelocity = _playerStats.RunMaxSpeed;
                OnChangeVelocity?.Invoke(_playerStats.RunMaxSpeed);
                break;
        }
    }

    public float GetVelocity()
    {
        return _characterVelocity;
    }

    public void SliderChangeVisibility()
    {
        if(_sliderMinigameController.isActiveAndEnabled)
        {
            _sliderMinigameController.HideSlider();
        }
        else
        {
            _sliderMinigameController.ShowSlider();
        }
    }
}
