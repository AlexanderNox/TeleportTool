using Infrastructure;
using UI;
using UnityEngine;
using Zenject;

public class LevelSelectionPagePresenter : MainMenuPagePresenter
{
    [SerializeField] private LevelSelectionPageView _levelSelectionPageView;
    [SerializeField] private StartPagePresenter _startPagePresenterPrefab;
    private LevelSelectionPage _levelSelectionPage;
    private SceneLoader _sceneLoader;
    private MainMenu _mainMenu;

    [Inject]
    private void Construct(SceneLoader sceneLoader, MainMenu mainMenu)
    {
        _sceneLoader = sceneLoader;
        _mainMenu = mainMenu;
    }
    
    private void Awake()
    {
        _levelSelectionPage = new LevelSelectionPage(
            _sceneLoader, _startPagePresenterPrefab, _mainMenu);
    }

    private void OnEnable()
    {
        _levelSelectionPageView.Level1ButtonClick += _levelSelectionPage.LoadLevel1;
        _levelSelectionPageView.Level2ButtonClick += _levelSelectionPage.LoadLevel2;
        _levelSelectionPageView.Level3ButtonClick += _levelSelectionPage.LoadLevel3;
        _levelSelectionPageView.BackButtonClick += _levelSelectionPage.BackPage;
    }
    
    private void OnDisable()
    {
        _levelSelectionPageView.Level1ButtonClick += _levelSelectionPage.LoadLevel1;
        _levelSelectionPageView.Level2ButtonClick += _levelSelectionPage.LoadLevel2;
        _levelSelectionPageView.Level3ButtonClick += _levelSelectionPage.LoadLevel3;
        _levelSelectionPageView.BackButtonClick += _levelSelectionPage.BackPage;
    }
}