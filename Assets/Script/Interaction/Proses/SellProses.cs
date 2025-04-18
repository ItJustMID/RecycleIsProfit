using System.Collections;
using UnityEngine;

public class SellProses : MonoBehaviour
{
    [SerializeField] Seller _seller;
    [SerializeField] AudioSource _audioSource;

    private void Start()
    {
        StartCoroutine(TimerCooldownCustomer());
    }

    public void GetShipping()
    {
        for (int i = 0; i < ManagerInvetori.Instance._listItem.Count; i++)
        {
            if (ManagerInvetori.Instance._listItem[i]._nameItem == _seller._nameItem)
            {
                CheckItemAvailable(i);
                return;
            }
        }
    }

    void CheckItemAvailable(int i)
    {
        if (_seller._amountItem > ManagerInvetori.Instance._listItem[i]._amountItem)
        {
            Debug.Log("item not enough");
            return;
        }

        _audioSource.Play();
        ManagerInvetori.Instance._listItem[i]._amountItem -= _seller._amountItem;
        ManagerInvetori.Instance.UpdateMoney(ManagerInvetori.Instance._listItem[i]._price * _seller._amountItem);
        ManagerUI.Instance.UpdateSellingReference(ManagerInvetori.Instance);

        StartCoroutine(TimerCooldownCustomer());
    }

    IEnumerator TimerCooldownCustomer()
    {
        yield return new WaitForSeconds(1);
        RandomSellStock.GetCustomer(_seller);
        ManagerUI.Instance.SellText(_seller);
    }
}