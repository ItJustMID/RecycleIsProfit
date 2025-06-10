using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoldingProcess : MonoBehaviour
{
    [SerializeField] GameObject _addAndReduceButton;
    [SerializeField] Slider _sliderTimer;
    [SerializeField] AudioSource _sfx;

    [Space(5), Header("Text Reference"), SerializeField]
    TextMeshProUGUI _amountText;
    [SerializeField] TextMeshProUGUI _maxAmountText;
    [SerializeField] TextMeshProUGUI _upgradeAmountText;
    [SerializeField] Image _upgradeImage;

    int _amount;
    int _maxAmount;
    int _addOrReduce;
    float _timerCountdown;
    string _nameItem;
    bool _isProsess = false;

    ManagerInvetori _managerInvetori;

    private void Start()
    {
        _managerInvetori = ManagerInvetori.Instance;

        if (_managerInvetori._upgradeArrayList == _managerInvetori._listUpgrade.Length) return;
        for (int i = 0; i < _managerInvetori._upgradeArrayList; i++)
        {
            _managerInvetori._listUpgrade[i]._buttonItem.SetActive(true);
        }
            _upgradeImage.sprite = _managerInvetori._listUpgrade[_managerInvetori._upgradeArrayList]._icon;
            _upgradeAmountText.text = _managerInvetori._listUpgrade[_managerInvetori._upgradeArrayList]._price.ToString("N0");
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
        if (_isProsess) return;

        for (int i = 0; i < _managerInvetori._listItem.Count; i++)
        {
            if (_managerInvetori._listItem[i]._nameItem == _nameItem && _managerInvetori._bijiPlastik._amountItem >= _managerInvetori._listItem[i]._amountNeeded)
            {
                _managerInvetori._listItem[i]._amountItem += _amount / _managerInvetori._listItem[i]._amountNeeded;
                _managerInvetori._bijiPlastik._amountItem -= _amount;

                _timerCountdown = 5;
                _sliderTimer.maxValue = _timerCountdown;
                _sliderTimer.value = _timerCountdown;

                StartCoroutine(TimerMolding());
                _sfx.Play();
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

        _amount = 0;
        GetUpdateText(_amountText, _maxAmountText);
    }

    public void ButtonUpgrade(GameObject button)
    {
        if (_managerInvetori._money >= _managerInvetori._listUpgrade[_managerInvetori._upgradeArrayList]._price)
        {
            StartCoroutine(ManagerInvetori.Instance.UpdateMoney(-_managerInvetori._listUpgrade[_managerInvetori._upgradeArrayList]._price));
            _managerInvetori._listUpgrade[  _managerInvetori._upgradeArrayList]._buttonItem.SetActive(true);
            _managerInvetori._listItem.Add(_managerInvetori._listUpgrade[   _managerInvetori._upgradeArrayList]._itemData);
            _managerInvetori._upgradeArrayList++;

            if (_managerInvetori._upgradeArrayList < ManagerInvetori.Instance._listUpgrade.Length)
            {
                _upgradeImage.sprite = _managerInvetori._listUpgrade[_managerInvetori._upgradeArrayList]._icon;
                _upgradeAmountText.text = _managerInvetori._listUpgrade[_managerInvetori._upgradeArrayList]._price.ToString("N0");
            }
            RandomSellStock.UpdateListItemSell();
            if (_managerInvetori._upgradeArrayList == _managerInvetori._listUpgrade.Length) button.SetActive(false);
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
            _isProsess = true;
            _timerCountdown -= Time.deltaTime;
            _sliderTimer.value = _timerCountdown;
            yield return null;
            if (_timerCountdown < 0)
            {
                ManagerUI.Instance.UpdateAmountItemToolbar();
                _amount = 0;
                _sfx.Stop();
                _isProsess = false;
            }
        }
    }
}