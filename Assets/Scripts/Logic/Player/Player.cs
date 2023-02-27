using System;
using UnityEngine;

namespace Infrastructure
{
    public class Player : MonoBehaviour
    {
        public event Action RestartRequest;

        public void InvokeRestartRequest()
        {
            RestartRequest?.Invoke();
        }
    }
}