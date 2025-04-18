using TMPro;
using UnityEngine;
using System.Collections.Generic;


public class ManagerInvetori : MonoBehaviour
{
    public static ManagerInvetori Instance;

    public InventorySlot[] _inventoriSlot;
    public InventorySlot _bijiPlastik;
    public List<ItemForSell> _listItem;
    public Upgrade[] _listUpgrade;

    [SerializeField] TextMeshProUGUI[] _amount;

    [Space(10)] public float _money;
    [SerializeField] TextMeshProUGUI _totalMoney;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        for(int i = 0; i < _amount.Length; i++)
        {
            _amount[i].text = _inventoriSlot[i]._amountItem.ToString();
        }
    }

    public void GetInventoryItem(string name)
    {
        for (int i = 0; i < _inventoriSlot.Length; i++)
        {
            if (_inventoriSlot[i]._nameItem == name)
            {
                _inventoriSlot[i]._amountItem++;
                return;
            }
        }
    }

    public void UpdateMoney(float amount)
    {
        _money += amount;
        _totalMoney.text = _money.ToString();
    }
}