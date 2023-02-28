using System;
using Logic;
using UnityEngine;

namespace Infrastructure
{
    public class Player : MonoBehaviour, IСanDie
    {
        public event Action RestartRequest;
        public event Action Died;

        public void InvokeRestartRequest()
        {
            RestartRequest?.Invoke();
        }

        public void Death()
        {
            RestartRequest?.Invoke();
            Died?.Invoke();
        }
    }
}