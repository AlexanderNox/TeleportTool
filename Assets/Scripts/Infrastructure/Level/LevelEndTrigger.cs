using System;
using UnityEngine;

namespace Infrastructure
{
    public class LevelEndTrigger : MonoBehaviour
    {
        public event Action Triggerred;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                Triggerred?.Invoke();
            }
        }
    }
}