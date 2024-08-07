using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public static int Walk { get; private set; } = Animator.StringToHash("Walk");

    public void PlayAnimation(int animationHash) => _animator.SetTrigger(animationHash);
    
    
}