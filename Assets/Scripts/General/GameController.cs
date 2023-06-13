using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Light _light;

    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;

    [SerializeField]
    private ScriptableObjectBoolVariable _isGameFinished;

    [SerializeField]
    private Animator _screenFadeAnimator;

    [SerializeField]
    private CanvasGroup _finishScreen;

    [SerializeField]
    private CharacterTriggerController _characterTriggerController;
    private void Awake()
    {
        ScreenFadeOut();
        _light.transform.rotation = Quaternion.Euler(50, -15, 0);
    }

    private void OnEnable()
    {
        //_isGameFinished.OnVariableChanged += FinishGame;
        _characterTriggerController.OnFinish += FinishGame;
    }

    private void OnDisable()
    {
        //_isGameFinished.OnVariableChanged -= FinishGame;
        _characterTriggerController.OnFinish -= FinishGame;
    }

    private void FinishGame()
    {
        _virtualCamera.gameObject.SetActive(false);
        _light.transform.rotation = Quaternion.Euler(135, -15, 0);
        _finishScreen.alpha = 1;
    }

    private void ScreenFadeOut()
    {
        _screenFadeAnimator.SetTrigger("FadeOut");
    }
}
