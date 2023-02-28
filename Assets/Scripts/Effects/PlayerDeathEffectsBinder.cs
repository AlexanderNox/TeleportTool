using Effects.PostProcessing;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Effects
{
    public class PlayerDeathEffectsBinder : MonoBehaviour
    {
        [SerializeField] private Player _player;
        private PostProcessingAnimator _postProcessingAnimator;

        [Inject]
        private void Construct(PostProcessingAnimator postProcessingAnimator)
        {
            _postProcessingAnimator = postProcessingAnimator;
        }

        private void OnEnable()
        {
            _player.Died += OnDied;
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
        }

        private void OnDied()
        {
            _postProcessingAnimator.StateMachine.Enter<DeathPostProcessingState>();
        }
    }
}
