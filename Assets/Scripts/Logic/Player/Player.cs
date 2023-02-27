using System;
using Logic;
using UnityEngine;

namespace Infrastructure
{
    public class Player : MonoBehaviour, IСanDie
    {
        [field: SerializeField] public Transform CameraPosition { get; private set; }
        public event Action RestartRequest;

        public void InvokeRestartRequest()
        {
            RestartRequest?.Invoke();
        }

        public void Death()
        {
            RestartRequest?.Invoke();
        }
    }
}