using Effects.PostProcessing;
using Logic.Metamorphos;
using UnityEngine;
using Zenject;

namespace Effects
{
    public class MetamorphosEffectsBinder : MonoBehaviour
    {
        [SerializeField] private MetamorphosedОbject _playerMetamorphosedОbject;
        private PostProcessingAnimator _postProcessingAnimator;

        [Inject]
        private void Construct(PostProcessingAnimator postProcessingAnimator)
        {
            _postProcessingAnimator = postProcessingAnimator;
        }

        private void OnEnable()
        {
            _playerMetamorphosedОbject.Metamorphosed += OnMetamorphosed;
        }

        private void OnDisable()
        {
            _playerMetamorphosedОbject.Metamorphosed -= OnMetamorphosed;
        }

        private void OnMetamorphosed()
        {
            _postProcessingAnimator.StateMachine.Enter<MetamorphosePostProcessingState>();
        }
    }
}
