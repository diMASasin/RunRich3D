using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Animator _arrowAnimator;
        [SerializeField] private Animator _appearanceAnimator;

        private static readonly int Move = Animator.StringToHash("Move");
        private static readonly int Appear = Animator.StringToHash("Appear");

        private void OnEnable()
        {
            _button.onClick.AddListener(OnNextButtonClick);
            
            _arrowAnimator.SetTrigger(Move);
            _appearanceAnimator.SetTrigger(Appear);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnNextButtonClick);
        }

        private void OnNextButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}