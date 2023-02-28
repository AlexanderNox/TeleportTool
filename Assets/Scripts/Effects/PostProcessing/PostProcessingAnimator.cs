using System;
using System.Collections.Generic;
using Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Effects.PostProcessing
{
    [RequireComponent(typeof(Volume))]
    public class PostProcessingAnimator : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private PostProcessingStateData _metamorphosePostProcessingStateData;
        [SerializeField] private PostProcessingStateData _idlePostProcessingStateData;
        [SerializeField] private PostProcessingStateData _deathPostProcessingStateData;
        public StateMachine StateMachine { get; private set;}
        private Volume _volume;
        private LensDistortion _lensDistortion;
        private Bloom _bloom;

        private event Action AnimationEnd;

        private void Awake()
        {
            _volume = GetComponent<Volume>();
            _volume.profile.TryGet(out _lensDistortion);
            _volume.profile.TryGet(out _bloom);
            AnimationEnd += OnAnimationEnd;// The subscription is located in Awake because
            // of the peculiarities of the StateMachine class implementation
            StateMachine = new StateMachine(GetStateMap());
        }

        private void OnDestroy()
        {
            AnimationEnd -= OnAnimationEnd;
        }

        private void OnAnimationEnd()
        {
            StateMachine.Enter<IdlePostProcessingState>();
        }

        private Dictionary<Type, IExitableState> GetStateMap()
        {
            Dictionary<Type, IExitableState> stateMap = new Dictionary<Type, IExitableState>()
            {
                [typeof(IdlePostProcessingState)] = new IdlePostProcessingState(
                    this, _lensDistortion, _idlePostProcessingStateData),
                [typeof(MetamorphosePostProcessingState)] = new MetamorphosePostProcessingState(
                    this, _lensDistortion, _metamorphosePostProcessingStateData, AnimationEnd),
                [typeof(DeathPostProcessingState)] = new DeathPostProcessingState(
                    this, _bloom, _deathPostProcessingStateData, AnimationEnd)
            };
        
            return stateMap;
        }
    }
}

  