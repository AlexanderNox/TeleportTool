using Infrastructure;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Game _prefab;
        
        public override void InstallBindings()
        {
            Game instance =
                Container.InstantiatePrefabForComponent<Game>(_prefab);
            
            Container
                .Bind<Game>()
                .FromComponentInNewPrefab(instance)
                .AsSingle();
        }
    }
}