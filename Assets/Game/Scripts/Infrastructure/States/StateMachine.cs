﻿using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.Infrastructure.States
{
    public static class StateMachine
    {
        private static readonly Dictionary<Type, IState> States = new();
        private static IState _currentState;
        
        public static void Init()
        {
            States.Add(typeof(MainState), new MainState());
        }
        
        public static void Enter<TState>() where TState: class, IEnterState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public static void Enter<TState, TArgs>(TArgs args) where TState: class, IEnterStateArgs<TArgs>
        {
            var state = ChangeState<TState>();
            state.Enter(args);
        }
        
        public static async UniTask EnterAsync<TState>() where TState: class, IEnterStateAsync
        {
            var state = ChangeState<TState>();
            await state.Enter();
        }
        
        public static async UniTask EnterAsync<TState, TArgs>(TArgs args) where TState: class, IEnterStateArgsAsync<TArgs>
        {
            var state = ChangeState<TState>();
            await state.Enter(args);
        }

        private static TState ChangeState<TState>() where TState : class, IState
        {
            if (_currentState is IExitState exitState)
                exitState.Exit();
            
            //UIManager.Clear();

            if (!States.TryGetValue(typeof(TState), out var state))
                throw new UnityException($"State {nameof(TState)} is not exist");

            _currentState = state;
            return state as TState;
        }
    }
}