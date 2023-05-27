using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMinigameController : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    private float _stepValueIncrease = 0.25f;
    private float _stepValueDecrease = -0.1f;
    private float _stepValueCurrent = 0;

    private void Start()
    {
        StartCoroutine(UpdateSlider());
    }

    private IEnumerator UpdateSlider()//убавление шкалы слайдера в зависимости от времени
    {
        while(true)
        {
            _slider.value += _stepValueCurrent;
            if(_stepValueCurrent==_stepValueIncrease)
            {
                _stepValueCurrent = _stepValueDecrease;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _stepValueCurrent = _stepValueIncrease;
        }
    }
}
