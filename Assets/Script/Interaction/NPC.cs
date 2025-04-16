using UnityEngine;

public class NPC : Interaction
{
    [SerializeField] GameObject _canvas;

    public override void GetInteraction()
    {
        _canvas.SetActive(true);
        CharacterMovement._canMove = false;
    }
}