using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoppingProcess : MonoBehaviour
{
    [SerializeField] RectTransform[] _position;
    [SerializeField] GameObject _addAndReduceButton;
    [SerializeField] TextMeshProUGUI _amountText;
    [SerializeField] Slider _sliderTimer;

    int _amount = 1;
    int _maxAmount;
    float _timerCountdown;
    string _nameItem;
    TextMeshProUGUI _amountItemText;

    ManagerInvetori _managerInventory;

    private void Start()
    {
        _managerInventory = ManagerInvetori.Instance;
    }

    public void AddAmount()
    {
        if (_amount < _maxAmount)
        {
            _amount++;
            _amountText.text = _amount.ToString();
        }
    }

    public void ReduceAmount()
    {
        if (_amount > 1)
        {
            _amount--;
            _amountText.text = _amount.ToString();
        }
    }

    public void Chopping()
    {
        for (int i = 0; i < _managerInventory._inventoriSlot.Length; i++)
        {
            if (_managerInventory._inventoriSlot[i]._nameItem == _nameItem && _managerInventory._inventoriSlot[i]._amountItem > 0)
            {
                _managerInventory._inventoriSlot[i]._amountItem -= _amount;
                _managerInventory._bijiPlastik._amountItem += _amount * _managerInventory._inventoriSlot[i]._multiplicationOfItem;

                _timerCountdown = 2f;
                _sliderTimer.maxValue = _timerCountdown;
                _sliderTimer.value = _timerCountdown;

                StartCoroutine(TimerChopping());
                return;
            }
            else if (_managerInventory._inventoriSlot[i]._nameItem == _nameItem && _managerInventory._inventoriSlot[i]._amountItem == 0)
            {
                Debug.Log("Item Not Enough");
            }
        }
    }

    public void ButtonItem(int number)
    {
        InventoryButtonText(number);

        _addAndReduceButton.GetComponent<RectTransform>().localPosition = new Vector3(-200, _position[number].localPosition.y, 0);

        ResetAmount();
    }

    public void GetText(TextMeshProUGUI amountText)
    {
        _amountItemText = amountText;
    }

    void ResetAmount()
    {
        _amount = 1;
        _amountText.text = _amount.ToString();
    }

    void InventoryButtonText(int number)
    {
        _nameItem = _managerInventory._inventoriSlot[number]._nameItem;
        _maxAmount = _managerInventory._inventoriSlot[number]._amountItem;

        _amountItemText.text = _maxAmount.ToString();
    }

    IEnumerator TimerChopping()
    {
        while (_timerCountdown > 0)
        {
            _timerCountdown -= Time.deltaTime;
            _sliderTimer.value = _timerCountdown;
            yield return null;
            if (_timerCountdown < 0)
            {
                ResetAmount();
            }
        }
    }
}