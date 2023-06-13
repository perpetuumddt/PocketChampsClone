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
        Max=2,
        Empty = 3
    }
    public event Action<bool> OnSliderOverflow;
    public event Action<SliderPosition> OnSliderPositionChanged;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private Image _sliderImage;

    private float _stepValueIncrease = 0.1f;
    private float _stepValueDecrease = -0.033f;
    private float _stepValueCurrent = 0;

    private float _sliderUpdateFrequency = 0.05f;

    private bool _isSliderOverflow;

    private void OnEnable()
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
            yield return new WaitForSeconds(_sliderUpdateFrequency);
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
        if(sliderValue>0 && sliderValue<=0.2 || sliderValue>=0.8 && sliderValue<1)
        {
            _sliderImage.color = Color.red;
            OnSliderPositionChanged?.Invoke(SliderPosition.Min);
        }
        if (sliderValue > 0.2 && sliderValue <= 0.4 || sliderValue >= 0.6 && sliderValue < 0.8)
        {
            _sliderImage.color = Color.yellow;
            OnSliderPositionChanged?.Invoke(SliderPosition.Middle);
        }
        if (sliderValue>0.4f && sliderValue<0.6f)
        {
            _sliderImage.color = Color.green;
            OnSliderPositionChanged?.Invoke(SliderPosition.Max);
        }
        if(sliderValue == 0)
        {
            OnSliderPositionChanged?.Invoke(SliderPosition.Empty);
        }
    }

    public void HideSlider()
    {
        this.gameObject.SetActive(false);
    }    

    public void ShowSlider()
    {
        this.gameObject.SetActive(true);
    }
}
