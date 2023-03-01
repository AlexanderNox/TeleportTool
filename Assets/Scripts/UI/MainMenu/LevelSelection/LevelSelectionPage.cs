using Infrastructure;
using UI;

public class LevelSelectionPage
{
    private const string SceneLevel1 = "Level01";
    private const string SceneLevel2 = "Level02";
    private const string SceneLevel3 = "Level03";
    private readonly SceneLoader _sceneLoader;
    private readonly StartPagePresenter _startPagePresenterPrefab;
    private readonly MainMenu _mainMenu;

    public LevelSelectionPage(SceneLoader sceneLoader,
        StartPagePresenter startPagePresenterPrefab, MainMenu mainMenu)
    {
        _sceneLoader = sceneLoader;
        _startPagePresenterPrefab = startPagePresenterPrefab;
        _mainMenu = mainMenu;
    }

    public void LoadLevel1() => _sceneLoader.Load(SceneLevel1);
    
    public void LoadLevel2() => _sceneLoader.Load(SceneLevel2);
    
    public void LoadLevel3() => _sceneLoader.Load(SceneLevel3);

    public void BackPage() => _mainMenu.Open(_startPagePresenterPrefab);
}