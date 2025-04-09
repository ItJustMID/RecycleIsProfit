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

    int _amount;
    int _maxAmount;
    int _addOrReduce;
    float _timerCountdown;
    string _nameItem;

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
        _timerCountdown = 2f;
        _sliderTimer.maxValue = _timerCountdown;
        _sliderTimer.value = _timerCountdown;

        StartCoroutine(TimerMolding());
    }

    public void ButtonItem(int number)
    {
        ManagerInvetori.Instance.GetButtonInfoMolding(number, ref _nameItem, ref _maxAmount, ref _addOrReduce);

        _addAndReduceButton.GetComponent<RectTransform>().localPosition = new Vector3(-200, _position[number].localPosition.y, 0);

        _amount = 0;
        GetUpdateText(_amountText, _maxAmountText);
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
                ManagerInvetori.Instance.GetReduceMoldingItem(_nameItem, _amount);
                _amount = 0;
            }
        }
    }
}