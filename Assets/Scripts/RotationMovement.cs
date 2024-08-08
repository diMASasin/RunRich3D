using RunnerMovementSystem;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    [SerializeField] private float _yRotationAngle = 70f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _returnSpeed = 5f;
    [SerializeField] private MovementSystem _movementSystem;

    private Quaternion _targetQuaternionOnEnabled =new Quaternion(0, 0, 0, 1);

    private float _previousOffset;
    private float _previousXPosition;
    private Quaternion _initialRotation;

    
    private void Awake()
    {
        _initialRotation = transform.localRotation;
    }
    
    private void OnPlayerReachedHome()
    {
        enabled = false;
    }
    
    private void Update()
    {
        TryReturnToDefaultRotation();
    }

    public void TryRotateTowardsDirection(Vector3 offset)
    {
        float directionModifier = offset.x > _previousOffset ? 1f : -1f;

        RotateMesh(directionModifier, offset.x);
    }

    private void RotateMesh(float directionModifier, float xOffset)
    {
        if (_previousOffset != xOffset && _previousXPosition != _movementSystem.Offset)
        {
            _previousXPosition = _movementSystem.Offset;
            _previousOffset = xOffset;

            Quaternion rotation = Quaternion.Euler(new Vector3(0f, _yRotationAngle * directionModifier, 0f));
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void TryReturnToDefaultRotation()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, _initialRotation, _returnSpeed * Time.deltaTime);
    }
}