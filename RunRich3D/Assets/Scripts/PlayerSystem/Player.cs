using RunnerMovementSystem;
using RunnerMovementSystem.Examples;
using UnityEngine;
using WalletSystem;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerAnimations _animations;
        [SerializeField] private MovementSystem _movementSystem;
        [SerializeField] private GameObject _currentSkin;
        
        private IInput _input;
        
        public Wallet Wallet { get; private set; }

        public void Init(Wallet wallet, IInput input)
        {
            _input = input;
            Wallet = wallet;
            
            _animations.Init(Wallet);
            
            Wallet.LevelIncreased += OnLevelIncreased;
        }

        private void Update()
        {
            _input.TryStartMove();
            
            if(_input.IsMoved == false)
                return;

            _animations.PlayAnimation(PlayerAnimations.SadWalk);
            float movementOffset = _input.GetMovementOffset();
            _movementSystem.SetOffset(movementOffset);
            _movementSystem.MoveForward();
        }

        private void OnDestroy()
        {
            Wallet.LevelIncreased -= OnLevelIncreased;
        }

        private void OnLevelIncreased(RichnessLevel richnessLevel)
        {
            _currentSkin.SetActive(false);
            _currentSkin = richnessLevel.Skin;
            _currentSkin.SetActive(true);
            
            _animations.PlayAnimation(PlayerAnimations.Spin);
        }

        public void Celebrate()
        {
            _movementSystem.enabled = false;
            _animations.PlayAnimation(PlayerAnimations.Celebrate);
        }

        public void Die()
        {
            _movementSystem.enabled = false;
            _animations.PlayAnimation(PlayerAnimations.Die);
        }
    }
}