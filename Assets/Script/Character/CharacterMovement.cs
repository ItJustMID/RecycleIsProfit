using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static bool _canMove = true;

    [SerializeField] float _speed;

    Rigidbody2D _rigidbody2D;
    Animator _animator;
    Interaction _interaction;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovementCharacter(CharacterInput._isMoving, CharacterInput._isFacing);
    }

    public void MovementCharacter(Vector2 movement, Vector2 facing)
    {
        if (!_canMove) return;

        _rigidbody2D.velocity = movement * _speed;

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("FacingHorizontal", facing.x);
        _animator.SetFloat("FacingVertical", facing.y);
    }

    public void GetGameObjectInteraction(ref bool interaction)
    {
        if (_interaction)
        {
            _interaction.GetInteraction();
            interaction = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _interaction = collision.GetComponent<Interaction>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interaction = null;
    }
}
