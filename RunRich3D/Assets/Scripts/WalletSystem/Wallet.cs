using System;
using System.Collections.Generic;
using UnityEngine;

namespace WalletSystem
{
    public class Wallet
    {
        private int _points;
        private List<RichnessLevel> _richnessLevels;
        private int _currentLevel;
        
        public event Action<int> PointsValueChanged;
        public event Action<RichnessLevel> LevelIncreased;

        public Wallet(List<RichnessLevel> richnessLevels)
        {
            _richnessLevels = richnessLevels;
            
            PointsValueChanged?.Invoke(_points);
        }

        public void Add(int value)
        {
            _points += value;
            PointsValueChanged?.Invoke(_points);
            
            if(_currentLevel >= _richnessLevels.Count)
                return;
            
            RichnessLevel currentRichnessLevel = _richnessLevels[_currentLevel];
            
            if (_points >= currentRichnessLevel.TargetValue)
            {
                LevelIncreased?.Invoke(currentRichnessLevel);
            
                _currentLevel++;
                Debug.Log($"{_currentLevel}");
            }
        }
    }
}