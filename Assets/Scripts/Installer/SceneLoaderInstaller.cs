using Infrastructure;
using Zenject;

namespace Installer
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<SceneLoader>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}