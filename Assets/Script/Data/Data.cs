using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public string _nameItem;
    public int _amountItem;
    public int _multiplicationOfItem;
}

[System.Serializable]
public class ItemForSell
{
    public string _nameItem;
    public int _amountItem;
    public int _amountNeeded;
    public int _price;
}

[System.Serializable]
public class Seller
{
    public string _nameItem;
    public int _amountItem;
    public int _priceItem;
}

[System.Serializable]
public class NumberGacha
{
    public int _minNumber;
    public int _maxNumber;
}

[System.Serializable]
public class Upgrade
{
    public Sprite _icon;
    public ItemForSell _itemData;
    public GameObject _buttonItem;
    public int _price;
}

[System.Serializable]
public class SaveProgress
{
    public InventorySlot[] _slot;
    public InventorySlot _bijiPlastikSave;
    public ItemForSell[] _items;
    public int _upgrade;
    public float _money;

    public SaveProgress(ManagerInvetori inventory)
    {
        _slot = new InventorySlot[inventory._inventoriSlot.Length];
        _items = new ItemForSell[inventory._listItem.Count];

        _slot = inventory._inventoriSlot;
        _bijiPlastikSave = inventory._bijiPlastik;
        _items = inventory._listItem.ToArray();
        _upgrade = inventory._upgradeArrayList;
        _money = inventory._money;
    }
}