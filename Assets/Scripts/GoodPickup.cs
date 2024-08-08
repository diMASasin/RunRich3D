using PlayerSystem;
using UnityEngine;

public class GoodPickup : MonoBehaviour
{
    [SerializeField] private int _points;
    [SerializeField] private ParticleSystem _particleSystem;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Wallet.Add(_points);
            
            _particleSystem.transform.parent = null;
            _particleSystem.Play();
            
            Destroy(gameObject);
        }
    }
}