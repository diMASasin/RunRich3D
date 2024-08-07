using System.Collections.Generic;
using Infrastructure.Factories;
using PlayerSystem;
using PlayerSystem.StateMachine;
using PlayerSystem.StateMachine.States;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UI;
using UnityEngine;
using WalletSystem;

namespace Infrastructure
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private UiRoot _uiRoot;
        [SerializeField] private WalletView _gameplayCanvasPrefab;
        [SerializeField] private Player _player;
        [SerializeField] private MouseInput _mouseInput;
        [SerializeField] private List<RichnessLevel> _richnessLevels;
        
        private DebugGameStateMachine _stateMachine;
        private Wallet _playerWallet;

        private void Start()
        {
            
            _playerWallet = new Wallet(_richnessLevels);
            
            // PlayerFactory playerFactory = new PlayerFactory(_playerPrefab, _playerWallet, _playerSpawnPoint, _roadSegment);
            // Player player = playerFactory.Create();
            _player.Init(_playerWallet, _mouseInput);
            
            WalletView gameplayCanvas = CreateWalletView();
            
            List<IGameState> states = new();
            _stateMachine = new DebugGameStateMachine(states);
            
            states.Add(new GameStartState(_stateMachine, _uiRoot, _mouseInput));
            states.Add(new GamplayState(_stateMachine, _player, _uiRoot));
            
            _stateMachine.SwitchState<GameStartState>();
        }

        private void Update()
        {
            if (_stateMachine != null) _stateMachine.Tick();
        }

        private WalletView CreateWalletView()
        {
            var walletView = Instantiate(_gameplayCanvasPrefab, _uiRoot.GameplayCanvas.transform);
            walletView.Init(_playerWallet);

            return walletView;
        }
    }
}