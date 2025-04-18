using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoldingProcess : MonoBehaviour
{
    [SerializeField] RectTransform[] _position;
    [SerializeField] GameObject _addAndReduceButton;
    [SerializeField] Slider _sliderTimer;

    [Space(5), Header("Text Reference"), SerializeField]
    TextMeshProUGUI _amountText;
    [SerializeField] TextMeshProUGUI _maxAmountText;
    [SerializeField] TextMeshProUGUI _upgradeAmountText;

    int _amount;
    int _maxAmount;
    int _addOrReduce;
    int _upgradeArrayList;
    float _timerCountdown;
    string _nameItem;

    ManagerInvetori _managerInvetori;

    private void Start()
    {
        _managerInvetori = ManagerInvetori.Instance;
        _upgradeAmountText.text = _managerInvetori._listUpgrade[_upgradeArrayList]._price.ToString();
    }

    public void AddAmount()
    {
        if (_amount <= (_maxAmount - _addOrReduce))
            _amount += _addOrReduce;

        GetUpdateText(_amountText, _maxAmountText);
    }

    public void ReduceAmount()
    {
        if (_amount > 1)
        {
            _amount -= _addOrReduce;
        }
        GetUpdateText(_amountText, _maxAmountText);
    }

    public void Molding()
    {
        for (int i = 0; i < _managerInvetori._listItem.Count; i++)
        {
            if (_managerInvetori._listItem[i]._nameItem == _nameItem && _managerInvetori._bijiPlastik._amountItem >= _managerInvetori._listItem[i]._amountNeeded)
            {
                _managerInvetori._listItem[i]._amountItem += _amount / _managerInvetori._listItem[i]._amountNeeded;
                _managerInvetori._bijiPlastik._amountItem -= _amount;

                _timerCountdown = 2f;
                _sliderTimer.maxValue = _timerCountdown;
                _sliderTimer.value = _timerCountdown;

                StartCoroutine(TimerMolding());
                return;
            }
            else if (_managerInvetori._listItem[i]._nameItem == _nameItem && _managerInvetori._bijiPlastik._amountItem - _amount < _managerInvetori._listItem[i]._amountNeeded)
            {
                Debug.Log("Item Not Enough");
            }
        }
    }

    public void ButtonItem(int number)
    {
        _nameItem = _managerInvetori._listItem[number]._nameItem;
        _addOrReduce = _managerInvetori._listItem[number]._amountNeeded;
        _maxAmount = _managerInvetori._bijiPlastik._amountItem;

        _addAndReduceButton.GetComponent<RectTransform>().localPosition = new Vector3(-200, _position[number].localPosition.y, 0);

        _amount = 0;
        GetUpdateText(_amountText, _maxAmountText);
    }

    public void ButtonUpgrade(GameObject button)
    {
        if (_managerInvetori._money >= _managerInvetori._listUpgrade[_upgradeArrayList]._price)
        {
            ManagerInvetori.Instance.UpdateMoney(-_managerInvetori._listUpgrade[_upgradeArrayList]._price);
            _managerInvetori._listUpgrade[_upgradeArrayList]._buttonItem.SetActive(true);
            _managerInvetori._listItem.Add(_managerInvetori._listUpgrade[_upgradeArrayList]._itemData);
            _upgradeArrayList++;

            RandomSellStock.UpdateListItemSell();
            if (_upgradeArrayList == _managerInvetori._listUpgrade.Length) button.SetActive(false);
        }
        else Debug.Log("Not Enough Money");
    }

    void GetUpdateText(TextMeshProUGUI amountText, TextMeshProUGUI maxAmount)
    {
        amountText.text = _amount.ToString();
        maxAmount.text = _maxAmount.ToString();
    }

    IEnumerator TimerMolding()
    {
        while (_timerCountdown > 0)
        {
            _timerCountdown -= Time.deltaTime;
            _sliderTimer.value = _timerCountdown;
            yield return null;
            if (_timerCountdown < 0)
            {
                ManagerUI.Instance.UpdateSellingReference(_managerInvetori);
                _amount = 0;
            }
        }
    }
}