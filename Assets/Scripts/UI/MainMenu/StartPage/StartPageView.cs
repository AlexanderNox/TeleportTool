using System;
using UnityEngine;
using UnityEngine.UI;

public class StartPageView : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;

    public event Action PlayButtonClick;
    public event Action ExitButtonClick;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    { 
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick() => PlayButtonClick?.Invoke();

    private void OnExitButtonClick() => ExitButtonClick?.Invoke();
 
}