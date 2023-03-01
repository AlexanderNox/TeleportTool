using UnityEngine;
using Zenject;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private MainMenuPagePresenter _startMainMenuPagePresenter;
        private MainMenuPagePresenter _currentMainMenuPagePresenter;
        private DiContainer _diContainer;

        [Inject]
        private void Construct( DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        private void Start()
        {
            Open(_startMainMenuPagePresenter);
        }

        public void Open(MainMenuPagePresenter mainMenuPagePresenter)
        {
            if (_currentMainMenuPagePresenter != null)
                Close();

            _currentMainMenuPagePresenter = _diContainer.InstantiatePrefab(mainMenuPagePresenter, transform).GetComponent<MainMenuPagePresenter>();
        }
        
        private void Close()
        {
            Destroy(_currentMainMenuPagePresenter.gameObject);
        }
    }
}