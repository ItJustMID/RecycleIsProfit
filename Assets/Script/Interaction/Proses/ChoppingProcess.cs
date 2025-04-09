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
        _timerCountdown = 2f;
        _sliderTimer.maxValue = _timerCountdown;
        _sliderTimer.value = _timerCountdown;

        StartCoroutine(TimerChopping());
    }

    public void ButtonItem(int number)
    {
        ManagerInvetori.Instance.GetButtonInfo(number, ref _nameItem, ref _amountItemText, ref _maxAmount);

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

    IEnumerator TimerChopping()
    {
        while (_timerCountdown > 0)
        {
            _timerCountdown -= Time.deltaTime;
            _sliderTimer.value = _timerCountdown;
            yield return null;
            if (_timerCountdown < 0)
            {
                ManagerInvetori.Instance.GetReduceChoppingItem(_nameItem, _amount);
                ResetAmount();
            }
        }
    }
}