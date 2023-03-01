using Infrastructure;
using UI;
using UnityEngine;
using Zenject;

public class StartPagePresenter : MainMenuPagePresenter
{
    [SerializeField] private LevelSelectionPagePresenter _levelSelectionPagePresenterPrefab;
    [SerializeField] private StartPageView _startPageView;
    private StartPage _startPage;
    private MainMenu _mainMenu;
    private Game _game;

    [Inject]
    private void Construct(Game game, MainMenu mainMenu)
    {
        _mainMenu = mainMenu;
        _game = game;
    }
    
    private void Awake()
    {
        _startPage = new StartPage(_game, _mainMenu, _levelSelectionPagePresenterPrefab);
    }

    private void OnEnable()
    {
        _startPageView.PlayButtonClick += _startPage.Play;
        _startPageView.ExitButtonClick += _startPage.Exit;
    }
    
    private void OnDisable()
    {
        _startPageView.PlayButtonClick -= _startPage.Play;
        _startPageView.ExitButtonClick -= _startPage.Exit;
    }
}