using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WalletSystem
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private List<RichnessLevel> _richnessLevels;
        
        private int _points;
        private int _currentLevel;

        public RichnessLevel CurrentRichnessLevel => 
            _currentLevel < _richnessLevels.Count ? _richnessLevels[_currentLevel] : _richnessLevels.Last();
        
        public RichnessLevel NextRichnessLevel => 
            _currentLevel + 1 < _richnessLevels.Count ? _richnessLevels[_currentLevel + 1] : _richnessLevels.Last();
        
        public event Action<int> PointsValueChanged;
        public event Action<RichnessLevel, RichnessLevel> LevelIncreased;

        private void Start()
        {
            PointsValueChanged?.Invoke(_points);
        }

        public void Add(int value)
        {
            _points += value;

            if (_points < 0)
                _points = 0;
            
            PointsValueChanged?.Invoke(_points);
            
            TryInreaseLevel();
        }

        private void TryInreaseLevel()
        {
            if (_currentLevel >= _richnessLevels.Count)
                return;
            
            if (_points >= CurrentRichnessLevel.TargetValue)
            {
                LevelIncreased?.Invoke(CurrentRichnessLevel, NextRichnessLevel);

                _points -= CurrentRichnessLevel.TargetValue;
                PointsValueChanged?.Invoke(_points);
                
                _currentLevel++;
                Debug.Log($"{_currentLevel}");
            }
        }
    }
}