using System.Collections;
using Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Effects.PostProcessing
{
    public class IdlePostProcessingState : IState
    {
        private const float UpdateRate = 0.03f;
        private ICoroutineRunner _coroutineRunner;
        private LensDistortion _lensDistortion;
        private PostProcessingStateData _postProcessingStateData;
        private float _startLensDistortionIntensity;
        private Coroutine _animation;

        public IdlePostProcessingState(ICoroutineRunner coroutineRunner, 
            LensDistortion lensDistortion, PostProcessingStateData postProcessingStateData)
        {
            _coroutineRunner = coroutineRunner;
            _lensDistortion = lensDistortion;
            _postProcessingStateData = postProcessingStateData;
        }
    
        public void Enter()
        {
            _startLensDistortionIntensity = _lensDistortion.intensity.value;
            _animation = _coroutineRunner.StartCoroutine(PlayAnimation());
        }
    
        public void Exit()
        {
            _coroutineRunner.StopCoroutine(_animation);
            _lensDistortion.intensity.value = _startLensDistortionIntensity;
        }
    
        private IEnumerator PlayAnimation()
        {
            while (true)
            {
                float currentAnimationDuration = 0;
                while (currentAnimationDuration < _postProcessingStateData.AnimationDuration)
                {
                    _lensDistortion.intensity.value = 
                        _startLensDistortionIntensity * _postProcessingStateData.AnimationCurve.Evaluate(Mathf.InverseLerp(
                            0, _postProcessingStateData.AnimationDuration, currentAnimationDuration));
            
                    currentAnimationDuration += UpdateRate;
                    yield return new WaitForSeconds(UpdateRate);
                }
            }
        }
    }
}