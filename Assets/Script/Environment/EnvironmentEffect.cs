using UnityEngine;
using UnityEngine.InputSystem;

public class EnvironmentEffect : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    int _spriteIndex;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteIndex = _spriteRenderer.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spriteRenderer.sortingOrder = 3;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _spriteRenderer.sortingOrder = _spriteIndex;
    }
}