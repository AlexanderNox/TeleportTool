using UI;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenu _instance;
        
        public override void InstallBindings()
        {
            Container
                .Bind<MainMenu>()
                .FromInstance(_instance)
                .AsSingle();
        }
    }
}