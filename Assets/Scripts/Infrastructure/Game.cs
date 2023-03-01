using Configs;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            _sceneLoader.Load(_gameConfig.StartScene);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}