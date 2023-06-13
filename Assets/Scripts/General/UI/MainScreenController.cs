using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MainScreenController : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _trainButton;
    [SerializeField]
    private Button _equipmentButton;
    [SerializeField]
    private Button _shopButton;
    [SerializeField]
    private GameObject _currencyFields;
    public void OnEnable()
    {
        _playButton.onClick.AddListener(Play);
    }

    public void OnDisable()
    {
        _playButton.onClick.RemoveListener(Play);
    }

    private async void Play()
    {
        HideAllElements();
        await Task.Delay(2000);
        SceneManager.LoadScene(1);
    }

    private void HideAllElements()
    {
        _playButton.gameObject.SetActive(false);
        _trainButton.gameObject.SetActive(false);
        _equipmentButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        _currencyFields.gameObject.SetActive(false);
    }
}
