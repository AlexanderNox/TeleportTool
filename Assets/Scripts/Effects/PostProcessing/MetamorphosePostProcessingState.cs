using System;
using System.Collections;
using Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Effects.PostProcessing
{
    public class MetamorphosePostProcessingState : IState
    {
        private const float UpdateRate = 0.03f;
        private ICoroutineRunner _coroutineRunner;
        private LensDistortion _lensDistortion;
        private PostProcessingStateData _postProcessingStateData;
        private float _startLensDistortionIntensity;
        private Action _animationEndCallback;

        public MetamorphosePostProcessingState(ICoroutineRunner coroutineRunner, 
            LensDistortion lensDistortion, PostProcessingStateData postProcessingStateData, Action animationEndCallback)
        {
            _coroutineRunner = coroutineRunner;
            _lensDistortion = lensDistortion;
            _postProcessingStateData = postProcessingStateData;
            _animationEndCallback = animationEndCallback;
        }
    
        public void Enter()
        {
            _startLensDistortionIntensity = _lensDistortion.intensity.value;
            _coroutineRunner.StartCoroutine(PlayAnimation());
        }
    
        public void Exit()
        {
            _lensDistortion.intensity.value = _startLensDistortionIntensity;
        }
    
        private IEnumerator PlayAnimation()
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
        
            _animationEndCallback.Invoke();
        }
    }
}