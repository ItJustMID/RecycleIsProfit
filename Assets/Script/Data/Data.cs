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
    public ItemForSell _itemData;
    public GameObject _buttonItem;
    public int _price;
}