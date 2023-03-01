using Infrastructure;
using UI;

public class StartPage
{
    private Game _game;
    private MainMenu _mainMenu;
    private LevelSelectionPagePresenter _levelSelectionPagePresenterPrefab;

    public StartPage(Game game, MainMenu mainMenu, 
        LevelSelectionPagePresenter levelSelectionPagePresenterPrefab)
    {
        _game = game;
        _mainMenu = mainMenu;
        _levelSelectionPagePresenterPrefab = levelSelectionPagePresenterPrefab;
    }

    public void Play()
    {
        _mainMenu.Open(_levelSelectionPagePresenterPrefab);
    }

    public void Exit()
    {
        _game.Exit();
    }
}