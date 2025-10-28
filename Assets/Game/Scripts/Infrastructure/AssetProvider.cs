﻿using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Gameplay.Data.Units;
using Game.Scripts.Infrastructure.Custom;
using Game.Scripts.Infrastructure.Services;
using Game.Scripts.Multiplayer;
using Game.Scripts.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts.Infrastructure
{
    public static class AssetProvider
    {
        private const string GUI_PATH = "GUI";
        private const string POPUPS_PATH = "Popups";
        private const string SOUNDS_PATH = "Sounds";
        private const string UNITS_PATH = "Units";
        private static readonly Dictionary<Type, MonoBehaviour> Assets = new();
        
        public static PlayerView GetPlayerView()
        {
            return GetResource<PlayerView>($"{UNITS_PATH}/PlayerView");
        }
        
        public static EnemyView GetEnemyView()
        {
            return GetResource<EnemyView>($"{UNITS_PATH}/EnemyView");
        }
        
        public static MultiplayerManager GetMultiplayerManager()
        {
            return GetResource<MultiplayerManager>($"{nameof(MultiplayerManager)}");
        }
        
        public static PlayerData GetPlayerData()
        {
            return GetResource<PlayerData>($"{nameof(PlayerData)}");
        }
        
        public static T GetPopup<T, U>() where T : PopupView<U> where U : PopupModel
        {
            if (Assets.ContainsKey(typeof(T)))
                return Assets[typeof(T)] as T;

            var path = $"{POPUPS_PATH}/{typeof(T).Name}";
            T res = Resources.Load<T>(path);
            if (res == null)
                throw new Exception($"Can't find popup with type {typeof(T).Name} by path {path}");

            Assets.Add(typeof(T), res);

            return res;
        }
        
        public static T GetGUI<T, U>() where T : GUIView<U> where U : GUIModel
        {
            if (Assets.ContainsKey(typeof(T)))
                return Assets[typeof(T)] as T;

            var path = $"{GUI_PATH}/{typeof(T).Name}";
            T res = Resources.Load<T>(path);
            if (res == null)
                throw new Exception($"Can't find GUI with type {typeof(T).Name} by path {path}");

            Assets.Add(typeof(T), res);

            return res;
        }
        
        public static List<AudioClip> GetAllSounds()
        {
            return Resources.LoadAll<AudioClip>($"{SOUNDS_PATH}").ToList();
        }
        
        private static T GetResource<T>(string path) where T : Object
        {
            var resource = Resources.Load<T>(path);
            if (resource == null)
            {
                Debug.LogError($"Resource by path {path} not found");
                return null;
            }
            
            var data = Object.Instantiate(resource);
            data.name = data.name.Replace("_", " ");
            data.name = data.name.Replace("(Clone)", "");

            return data;
        }

        public static CustomButtonStyle GetCustomButtonStyle(CustomButtonSettings.Style style)
        {
            return Resources.Load<CustomButtonStyle>($"Buttons/{style}");
        }
    }
}