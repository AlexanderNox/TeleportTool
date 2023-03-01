using System;
using UnityEngine;

namespace Infrastructure
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public event Action ScreenHide;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            _animator.SetBool("Show",true);
        }

        public void Hide()
        {
            _animator.SetBool("Show",false);
        }

        //Method "InvokeScreenHide"  needed to invoke the event from the animator,
        //which gives flexibility in terms of creating animated transitions
        public void InvokeScreenHide() 
        {
            ScreenHide?.Invoke();
        }
    }
}