using UnityEngine;

public class RandomSellStock : MonoBehaviour
{
    static string[] _nameItems;

    private void Start()
    {
        UpdateListItemSell();
    }

    public static void UpdateListItemSell()
    {
        _nameItems = new string[ManagerInvetori.Instance._listItem.Count];
        for (int i = 0; i < _nameItems.Length; i++)
        {
            _nameItems[i] = ManagerInvetori.Instance._listItem[i]._nameItem;
        }
    }

    public static void GetCustomer(Seller seller)
    {
        seller._nameItem = _nameItems[Random.Range(0, _nameItems.Length)];
        seller._amountItem = Random.Range(1, 11);
        for (int i = 0; i < _nameItems.Length; i++)
        {
            if (seller._nameItem == ManagerInvetori.Instance._listItem[i]._nameItem)
            {
                seller._priceItem = seller._amountItem * ManagerInvetori.Instance._listItem[i]._price;
            }
        }
    }
}