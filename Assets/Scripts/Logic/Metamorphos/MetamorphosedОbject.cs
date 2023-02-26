using UnityEngine;
using static Extentions.UnityExtension;

namespace Logic
{
    [RequireComponent(typeof(Rigidbody))]
    public class MetamorphosedОbject : MonoBehaviour, IMetamorphosable
    {
        private Rigidbody _rigidbody;

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
        }
    }
}