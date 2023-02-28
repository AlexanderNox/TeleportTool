using Effects.PostProcessing;
using UnityEngine;
using Zenject;

public class PostProcessingInstaller : MonoInstaller
{
    [SerializeField] private PostProcessingAnimator _prefab;
    public override void InstallBindings()
    {
        PostProcessingAnimator instance =
            Container.InstantiatePrefabForComponent<PostProcessingAnimator>(_prefab);
        
        
        Container
            .Bind<PostProcessingAnimator>()
            .FromInstance(instance)
            .AsSingle();
    }
}