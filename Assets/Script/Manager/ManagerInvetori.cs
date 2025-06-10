using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class ManagerInvetori : MonoBehaviour
{
    public static ManagerInvetori Instance;

    public InventorySlot[] _inventoriSlot;
    public InventorySlot _bijiPlastik;
    public List<ItemForSell> _listItem;
    public Upgrade[] _listUpgrade;
    public int _upgradeArrayList;

    [SerializeField, Space(10)] TextMeshProUGUI _totalMoney;
    public float _money;
    float _moneyText;

    private void Awake()
    {
        Instance = this;
        SaveSystem.instance.LoadFile();
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

    public IEnumerator UpdateMoney(float amount)
    {
        _money += amount;
        while (_moneyText != _money + amount)
        {
            _moneyText = Mathf.MoveTowards(_moneyText, _money, 500 * Time.deltaTime);
            _totalMoney.text = _moneyText.ToString("N0");
            yield return new WaitWhile(() => _moneyText == _money);
        }
    }
}