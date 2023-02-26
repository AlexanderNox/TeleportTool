using Configs;
using UnityEngine;
using Zenject;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Start()
    {
        _sceneLoader.Load(_gameConfig.StartScene);
    }
}