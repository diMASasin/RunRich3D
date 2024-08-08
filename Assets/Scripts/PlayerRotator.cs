using RunnerMovementSystem.Examples;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private MouseInput _mouseInput;

        private void Update()
        {
            transform.rotation *= Quaternion.Euler(0, _mouseInput.GetMovementOffset() * Time.deltaTime, 0);
        }
    }
}