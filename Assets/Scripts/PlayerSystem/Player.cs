using System;
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
        [SerializeField] private Wallet _wallet;
        [SerializeField] private MouseInput2 _mouseInput;
        [SerializeField] private ParticleSystem _pukeEffect;
        [SerializeField] private ParticleSystem _levelUpEffect;
        
        public Wallet Wallet => _wallet;

        public event Action Died;
        
        public void Start()
        {
            _animations.Init(Wallet);
        }

        private void OnEnable()
        {
            Wallet.LevelIncreased += OnLevelIncreased;
            _mouseInput.Touched += OnTouched;
        }

        private void OnDisable()
        {
            Wallet.LevelIncreased -= OnLevelIncreased;
            _mouseInput.Touched -= OnTouched;
        }

        private void OnTouched()
        {
            _animations.PlayAnimation(PlayerAnimations.SadWalk);
        }

        private void OnLevelIncreased(RichnessLevel richnessLevel, RichnessLevel nextLevel)
        {
            _currentSkin.SetActive(false);
            _currentSkin = richnessLevel.Skin;
            _currentSkin.SetActive(true);
            
            _levelUpEffect.Play();
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
            
            Died?.Invoke();
        }

        public void Puke()
        {
            _pukeEffect.Play();
        }
    }
}