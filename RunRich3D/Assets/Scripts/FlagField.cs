using PlayerSystem;
using UnityEngine;

public class FlagField : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int Play = Animator.StringToHash("Play");
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _animator.SetTrigger(Play);
        }    
    }
}