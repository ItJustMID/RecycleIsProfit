using TMPro;
using UnityEngine;

public class ManagerInvetori : MonoBehaviour
{
    public static ManagerInvetori Instance;

    public InventorySlot[] _inventoriSlot;
    public InventorySlot _bijiPlastik;
    public ItemForSell[] _listItem;

    [SerializeField] TextMeshProUGUI[] _amount;

    [Space(10), SerializeField] float _money;
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

    public void GetReduceChoppingItem(string name, int amount)
    {
        for (int i = 0; i < _inventoriSlot.Length; i++)
        {
            if (_inventoriSlot[i]._nameItem == name)
            {
                if (_inventoriSlot[i]._amountItem - amount >= 0)
                {
                    _inventoriSlot[i]._amountItem -= amount;
                    _bijiPlastik._amountItem += amount * _inventoriSlot[i]._multiplicationOfItem;
                    return;
                }
                else Debug.Log("Item Not Enough");
            }
        }
    }

    public void GetReduceMoldingItem(string name, int amount)
    {
        for (int i = 0; i < _listItem.Length; i++)
        {
            if (_listItem[i]._nameItem == name)
            {
                if (_bijiPlastik._amountItem - amount >= 0)
                {
                    _listItem[i]._amountItem += amount / _listItem[i]._amountNeeded;
                    _bijiPlastik._amountItem -= amount;

                    ManagerUI.Instance.UpdateSellingReference(this);
                    return;
                }
                else Debug.Log("Item Not Enough");
            }
        }
    }

    public void GetButtonInfo(int number, ref string name, ref TextMeshProUGUI text, ref int maxAmount)
    {
        name = _inventoriSlot[number]._nameItem;
        maxAmount = _inventoriSlot[number]._amountItem;

        text.text = _inventoriSlot[number]._amountItem.ToString();
    }

    public void GetButtonInfoMolding(int number, ref string name, ref int maxAmount, ref int addOrReduce)
    {
        name = _listItem[number]._nameItem;
        addOrReduce = _listItem[number]._amountNeeded;
        maxAmount = _bijiPlastik._amountItem;
    }

    public int GetAmountNeeded(string name, ref int amount)
    {
        for (int i = 0; i < _listItem.Length; i++)
        {
            if (_listItem[i]._nameItem == name) amount = _listItem[i]._amountNeeded;
        }
        return amount;
    }

    public void UpdateMoney(float amount)
    {
        _money += amount;
        _totalMoney.text = _money.ToString();
    }
}