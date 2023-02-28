using System;
using System.Collections;
using Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Effects.PostProcessing
{
    public class DeathPostProcessingState : IState
    {
        private const float UpdateRate = 0.03f;
        private ICoroutineRunner _coroutineRunner;
        private Bloom _bloom;
        private PostProcessingStateData _postProcessingStateData;
        private float _startBloomIntensity;
        private Action _animationEndCallback;

        public DeathPostProcessingState(ICoroutineRunner coroutineRunner, 
            Bloom bloom, PostProcessingStateData postProcessingStateData, Action animationEndCallback)
        {
            _coroutineRunner = coroutineRunner;
            _bloom = bloom;
            _postProcessingStateData = postProcessingStateData;
            _animationEndCallback = animationEndCallback;
        }
    
        public void Enter()
        {
            _startBloomIntensity = _bloom.intensity.value;
            _coroutineRunner.StartCoroutine(PlayAnimation());
        }
    
        public void Exit()
        {
            _bloom.intensity.value = _startBloomIntensity;
        }
    
        private IEnumerator PlayAnimation()
        {
            float currentAnimationDuration = 0;
            while (currentAnimationDuration < _postProcessingStateData.AnimationDuration)
            {
                _bloom.intensity.value = 
                    _startBloomIntensity * _postProcessingStateData.AnimationCurve.Evaluate(Mathf.InverseLerp(
                        0, _postProcessingStateData.AnimationDuration, currentAnimationDuration));
                Debug.Log(_bloom.intensity.value.ToString());
            
                currentAnimationDuration += UpdateRate;
                yield return new WaitForSeconds(UpdateRate);
            }
        
            _animationEndCallback?.Invoke();
        }
    }
}