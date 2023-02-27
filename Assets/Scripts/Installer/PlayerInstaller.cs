using Infrastructure;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _prefab;
        [SerializeField] private Transform _spawnPosition;
            
        public override void InstallBindings()
        {
            Player player =
                Container.InstantiatePrefabForComponent<Player>(_prefab, _spawnPosition.position,
                    _spawnPosition.rotation, null);

            Container
                .Bind<Player>()
                .FromInstance(player)
                .AsSingle();
        }
    }
}