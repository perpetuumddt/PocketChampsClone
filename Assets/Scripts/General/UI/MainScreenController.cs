using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _trainButton;

    public void OnEnable()
    {
        _playButton.onClick.AddListener(Play);
    }

    public void OnDisable()
    {
        _playButton.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }
}
