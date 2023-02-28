using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.StateMachine
{
    public class StateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public StateMachine(Dictionary<Type, IExitableState> states)
        {
            _states = states;
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) 
            where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() 
            where TState : class, IExitableState
        {
            _currentState?.Exit();
            
            TState state = GetState<TState>();
            _currentState = state;
      
            return state;
        }

        private TState GetState<TState>() 
            where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}