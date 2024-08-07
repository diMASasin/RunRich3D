using PlayerSystem;
using UnityEngine;

public class ChooseGate : MonoBehaviour
{
    [SerializeField] private int  _bonus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Wallet.Add(_bonus);
            Debug.Log($"{_bonus}");
        }
    }
}