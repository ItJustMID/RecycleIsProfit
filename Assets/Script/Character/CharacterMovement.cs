using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] GameObject _interactionPopUp;
    [SerializeField] float _speed;

    public static bool _canMove = true;

    Rigidbody2D _rigidbody2D;
    Animator _animator;
    Interaction _interaction;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void GetGameObjectInteraction(ref bool interaction)
    {
        if (_interaction)
        {
            _interaction.GetInteraction();
            _interactionPopUp.SetActive(false);
            interaction = false;
        }
    }

    public void MovementCharacter(Vector2 movement, Vector2 facing)
    {
        if (!_canMove) return;

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("FacingHorizontal", facing.x);
        _animator.SetFloat("FacingVertical", facing.y);

        _rigidbody2D.velocity = movement * _speed;
    }

    public static void SetMovementCharacter(bool isMoving)
    {
        _canMove = isMoving;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _interaction = collision.GetComponent<Interaction>();
        if (_interaction != null) _interactionPopUp.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interaction = null;
        _interactionPopUp.SetActive(false);
    }
}
