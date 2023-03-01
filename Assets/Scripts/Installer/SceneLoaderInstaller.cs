using Infrastructure;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField] private SceneLoader _prefab;
        public override void InstallBindings()
        {
            Container
                .Bind<SceneLoader>()
                .FromComponentInNewPrefab(_prefab)
                .AsSingle();
        }
    }
}