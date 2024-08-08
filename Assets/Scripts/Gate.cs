using PlayerSystem;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private static readonly int Open = Animator.StringToHash("Open");

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _animator.SetTrigger(Open);
        }
    }
}