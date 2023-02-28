using System;
using UnityEngine;
using static Extensions.UnityExtension;

namespace Logic.Metamorphos
{
    [RequireComponent(typeof(Rigidbody))]
    public class MetamorphosedОbject : MonoBehaviour, IMetamorphosable
    {
        private Rigidbody _rigidbody;
        
        public event Action Metamorphosed; 
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public MetamorphosData GetMetamorphosData()
        {
            return new MetamorphosData(transform, _rigidbody);
        }

        public void Metamorphos(MetamorphosData enteringMetamorphosData)
        {
            transform.ApplyMetamorphos(enteringMetamorphosData);
          _rigidbody.ApplyMetamorphos(enteringMetamorphosData);
          Metamorphosed?.Invoke();
        }
    }
}