using UnityEngine;

public class RandomSellStock : MonoBehaviour
{
    static string[] _nameItems;
    static int _numberArray = 0;

    private void Start()
    {
        _nameItems = new string[ManagerInvetori.Instance._listItem.Length];
        for (int i = 0; i < _nameItems.Length; i++)
        {
            _nameItems[i] = ManagerInvetori.Instance._listItem[i]._nameItem;
        }
    }

    public static void GetCustomer(Seller seller)
    {
        seller._nameItem = _nameItems[_numberArray];
        seller._amountItem = Random.Range(1, 11);
        if (_numberArray < _nameItems.Length - 1)
            _numberArray++;
        else
            _numberArray = 0;
    }
}