using System.Collections;
using UnityEngine;

public class SellProses : MonoBehaviour
{
    [SerializeField] Seller[] _seller;
    [SerializeField] AudioSource _audioSource;

    public int _sellerCount = 0;

    private void Start()
    {
        StartCoroutine(TimerCooldownCustomer());
    }

    public void GetShipping(int indexButton)
    {
        for (int i = 0; i < ManagerInvetori.Instance._listItem.Count; i++)
        {
            if (_seller[indexButton]._nameItem == ManagerInvetori.Instance._listItem[i]._nameItem)
            {
                CheckItemAvailable(i, indexButton);
                return;
            }
        }
    }

    void CheckItemAvailable(int i, int indexButton)
    {
        if (_seller[indexButton]._amountItem > ManagerInvetori.Instance._listItem[i]._amountItem)
        {
            Debug.Log("item not enough");
            return;
        }

        _audioSource.Play();
        ManagerInvetori.Instance._listItem[i]._amountItem -= _seller[indexButton]._amountItem;
        StartCoroutine(ManagerInvetori.Instance.UpdateMoney(ManagerInvetori.Instance._listItem[i]._price * _seller[indexButton]._amountItem));
        ManagerUI.Instance.UpdateAmountItemToolbar();

        StartCoroutine(GetSeller(indexButton));
    }

    IEnumerator TimerCooldownCustomer()
    {
        while (_sellerCount < _seller.Length)
        {
            yield return new WaitForSeconds(1);
            RandomSellStock.GetCustomer(_seller[_sellerCount]);
            //ManagerUI.Instance.SellText(_seller);
            ManagerUI.Instance.ShowSellButton(_seller[_sellerCount], _sellerCount);
            _sellerCount++;
        }
    }

    IEnumerator GetSeller(int index)
    {
        ManagerUI.Instance.HideSellButton(index);
        yield return new WaitForSeconds(1);
        RandomSellStock.GetCustomer(_seller[index]);
        //ManagerUI.Instance.SellText(_seller);
        ManagerUI.Instance.ShowSellButton(_seller[index], index);
    }
}