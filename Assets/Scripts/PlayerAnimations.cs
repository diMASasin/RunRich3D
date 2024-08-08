using UnityEngine;
using WalletSystem;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private Wallet _wallet;

    public static int SadWalk { get; private set; } = Animator.StringToHash("SadWalk");
    public static int Spin { get; private set; } = Animator.StringToHash("Spin");
    public static int RichnessLevel { get; private set; } = Animator.StringToHash("RichnessLevel");
    public static int Celebrate { get; private set; } = Animator.StringToHash("Celebrate");
    public static int Die { get; private set; } = Animator.StringToHash("Die");

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
        
        _wallet.LevelIncreased += OnLevelIncreased;
    }
    
    private void OnDestroy()
    {
        _wallet.LevelIncreased -= OnLevelIncreased;
    }

    private void OnLevelIncreased(RichnessLevel richnessLevel, RichnessLevel nextLevel)
    {
        int richnessLevelIndex = _animator.GetInteger(RichnessLevel);
        _animator.SetInteger(RichnessLevel, richnessLevelIndex + 1);
    }

    public void PlayAnimation(int animationHash) => _animator.SetTrigger(animationHash);
}