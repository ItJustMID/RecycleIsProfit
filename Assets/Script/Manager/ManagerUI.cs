using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;

    [Header("Option Button")] public GameObject _optionButton;

    [SerializeField, Header("Selling Reference"), Space(10)] TextMeshProUGUI[] _textItemForSell;
    [SerializeField] TextMeshProUGUI _itemSell;
    [SerializeField] TextMeshProUGUI _amountItemSell;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateSellingReference(ManagerInvetori managerInvetori)
    {
        for (int i = 0; i < managerInvetori._listItem.Count; i++)
        {
            _textItemForSell[i].text = managerInvetori._listItem[i]._amountItem.ToString();
        }
    }

    public void SellText(Seller seller)
    {
        _itemSell.text = seller._nameItem.ToString();
        _amountItemSell.text = seller._amountItem.ToString();
    }

    public void Option() => Time.timeScale = 0;

    public void Resume() => Time.timeScale = 1;
}
