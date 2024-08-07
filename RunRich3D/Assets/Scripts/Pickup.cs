using PlayerSystem;
using UnityEngine;
using WalletSystem;

public class Pickup : MonoBehaviour
{
    [SerializeField] private int _points;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Wallet.Add(_points);
            Destroy(gameObject);
        }
    }
}