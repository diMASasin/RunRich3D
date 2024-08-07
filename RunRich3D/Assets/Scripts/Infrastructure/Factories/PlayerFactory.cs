using PlayerSystem;
using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;
using WalletSystem;

namespace Infrastructure.Factories
{
    public class PlayerFactory
    {
        private readonly Wallet _wallet;
        private readonly Player _prefab;
        private readonly Transform _playerSpawnPoint;
        private RoadSegment _roadSegment;

        public PlayerFactory(Player prefab, Wallet wallet, Transform playerSpawnPoint, RoadSegment roadSegment)
        {
            _roadSegment = roadSegment;
            _prefab = prefab;
            _wallet = wallet;
            _playerSpawnPoint = playerSpawnPoint;
        }
        
        public Player Create()
        {
            Player player = Object.Instantiate(_prefab, _playerSpawnPoint.position, Quaternion.identity);
            // player.Init(_wallet);

            return player;
        }
    }
}