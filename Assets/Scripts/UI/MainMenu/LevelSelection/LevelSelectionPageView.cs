using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPageView : MonoBehaviour
{
    [SerializeField] private Button _level1Button;
    [SerializeField] private Button _level2Button;
    [SerializeField] private Button _level3Button;
    [SerializeField] private Button _backButton;

    public event Action Level1ButtonClick;
    public event Action Level2ButtonClick;
    public event Action Level3ButtonClick;
    public event Action BackButtonClick;
    
    private void OnEnable()
    {
        _level1Button.onClick.AddListener(OnLevel1ButtonClick); 
        _level2Button.onClick.AddListener(OnLevel2ButtonClick); 
        _level3Button.onClick.AddListener(OnLevel3ButtonClick); 
        _backButton.onClick.AddListener(OnBackButtonClick); 
    }

    private void OnDisable()
    {
        _level1Button.onClick.RemoveListener(OnLevel1ButtonClick); 
        _level2Button.onClick.RemoveListener(OnLevel2ButtonClick); 
        _level3Button.onClick.RemoveListener(OnLevel3ButtonClick); 
        _backButton.onClick.RemoveListener(OnBackButtonClick); 
    }

    private void OnLevel1ButtonClick() => Level1ButtonClick?.Invoke();
    
    private void OnLevel2ButtonClick() => Level2ButtonClick?.Invoke();
    
    private void OnLevel3ButtonClick() => Level3ButtonClick?.Invoke();
    
    private void OnBackButtonClick() => BackButtonClick?.Invoke();
}