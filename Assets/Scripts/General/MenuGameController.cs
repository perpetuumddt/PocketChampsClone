using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameController : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Animator _screenFadeAnimator;

    [SerializeField]
    private GameObject _idleCat;

    [SerializeField]
    private GameObject _runningCat;
    private void OnEnable()
    {
        _playButton.onClick.AddListener(ChangeLevel);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(ChangeLevel);
    }

    private void ChangeLevel()
    {
        _idleCat.gameObject.SetActive(false);
        _runningCat.transform.position = new Vector3(0,2,1);
        StartCoroutine(MoveCat());
        ScreenFadeIn();
    }

    private void ScreenFadeIn()
    {
        _screenFadeAnimator.SetTrigger("FadeIn");
    }

    private IEnumerator MoveCat()
    {
        Vector3 startingPos = _runningCat.transform.position;
        Vector3 endPos = startingPos + (_runningCat.transform.forward*10);

        float elapsedTime = 0f;
        float time = 2f;

        while(elapsedTime<time)
        {
            _runningCat.transform.position = Vector3.Lerp(startingPos, endPos, (elapsedTime/time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
    }
}
