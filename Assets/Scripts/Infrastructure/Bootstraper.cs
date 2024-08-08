using PlayerSystem;
using RunnerMovementSystem.Examples;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private UiRoot _uiRoot;
        [SerializeField] private Player _player;
        [SerializeField] private Finish _finish;
        [SerializeField] private MouseInput2 _input;

        private void OnEnable()
        {
            _input.Touched += OnMovementStarted;
            _finish.Finished += OnFinished;
            _player.Died += OnDied;
        }

        private void OnDisable()
        {
            _input.Touched -= OnMovementStarted;
            _finish.Finished -= OnFinished;
            _player.Died -= OnDied;
        }

        private void OnMovementStarted()
        {
            _uiRoot.StartCanvas.gameObject.SetActive(false);
            _uiRoot.GameplayCanvas.gameObject.SetActive(true);
        }

        private void OnFinished()
        {
            _uiRoot.WinCanvas.gameObject.SetActive(true);
        }

        private void OnDied()
        {
            _uiRoot.LoseCanvas.gameObject.SetActive(true);
        }
    }
}