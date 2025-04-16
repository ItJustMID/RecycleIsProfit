using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;

    [SerializeField, Header("Selling Reference")] TextMeshProUGUI[] _textItemForSell;
    [SerializeField] TextMeshProUGUI _itemSell;
    [SerializeField] TextMeshProUGUI _amountItemSell;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateSellingReference(ManagerInvetori managerInvetori)
    {
        for (int i = 0; i < _textItemForSell.Length; i++)
        {
            _textItemForSell[i].text = managerInvetori._listItem[i]._amountItem.ToString();
        }
    }

    public void SellText(Seller seller)
    {
        _itemSell.text = seller._nameItem.ToString();
        _amountItemSell.text = seller._amountItem.ToString();
    }

    public void MoveCharacter() => CharacterMovement._canMove = true;
}
