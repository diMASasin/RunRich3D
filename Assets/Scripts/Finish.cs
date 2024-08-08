using System;
using PlayerSystem;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public event Action Finished;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Celebrate();
            Finished?.Invoke();
        }
    }
}