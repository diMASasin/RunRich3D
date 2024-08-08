using PlayerSystem;
using UnityEngine;

public class BadPickup : MonoBehaviour
{
    [SerializeField] private int _points;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Wallet.Add(_points);
            player.Puke();
            
            Destroy(gameObject);
        }
    }
}