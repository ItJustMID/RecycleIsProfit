using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class CharacterInput : MonoBehaviour
{
    Vector2 _isMoving;
    Vector2 _isFacing;
    bool _isInteracting;

    CharacterMovement _characterMovement;

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void FixedUpdate()
    {
        _characterMovement.MovementCharacter(_isMoving, _isFacing);
    }

    private void OnMove(InputValue value)
    {
        _isMoving = value.Get<Vector2>();
        if (_isMoving != Vector2.zero)
        {
            _isFacing = value.Get<Vector2>();
        }
    }

    private void OnInteraction(InputValue value)
    {
        _isInteracting = value.isPressed;

        _characterMovement.GetGameObjectInteraction(ref _isInteracting);
    }
}