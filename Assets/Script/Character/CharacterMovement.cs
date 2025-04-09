using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    Interaction _interaction;

    float _speed;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void MovementCharacter(Vector2 movement, Vector2 facing)
    {
        if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1) _speed = 2;
        else _speed = 1.6f;

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
