using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMinigameController : MonoBehaviour
{
    public enum SliderPosition
    {
        Min=0,
        Middle=1,
        Max=2
    }
    public event Action<bool> OnSliderOverflow;
    public event Action<SliderPosition> OnSliderPositionChanged;

    [SerializeField]
    private Slider _slider;

    private float _stepValueIncrease = 0.15f;
    private float _stepValueDecrease = -0.05f;
    private float _stepValueCurrent = 0;

    private bool _isSliderOverflow;

    private void Start()
    {
        StartCoroutine(UpdateSlider());
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IncreaseStepValue();
        }
    }


    private IEnumerator UpdateSlider()//убавление шкалы слайдера в зависимости от времени
    {
        while(true)
        {
            _slider.value += _stepValueCurrent;
            CheckSliderOverflow(_slider.value);
            CheckSliderPosition(_slider.value);
            if (_stepValueCurrent==_stepValueIncrease)
            {
                _stepValueCurrent = _stepValueDecrease;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void IncreaseStepValue()
    {
        if(_isSliderOverflow)
        {
            return;
        }
        _stepValueCurrent = _stepValueIncrease;
    }    

    private void CheckSliderOverflow(float sliderValue)
    {
        if (!_isSliderOverflow && sliderValue == 1)
        {
            _isSliderOverflow = true;
            OnSliderOverflow?.Invoke(true);
        }
        else if(_isSliderOverflow && sliderValue ==0)
        {
            _isSliderOverflow = false;
            OnSliderOverflow?.Invoke(false);
        }
    }

    private void CheckSliderPosition(float sliderValue)
    {
        if(sliderValue>0 && sliderValue<=0.25 || sliderValue>=0.75 && sliderValue<1)
        {
            OnSliderPositionChanged?.Invoke(SliderPosition.Min);
        }    
    }
}
