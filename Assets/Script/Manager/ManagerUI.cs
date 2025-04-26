using DG.Tweening;
using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI Instance;

    [Header("Option Button")] public GameObject _optionButton;

    [SerializeField, Header("Selling Reference"), Space(10)] RectTransform[] _buttonSeller;

    [SerializeField, Header("Toolbar Reference"), Space(10)] RectTransform _toolbarObject;
    [SerializeField] TextMeshProUGUI[] _amountRubbish;
    [SerializeField] TextMeshProUGUI _amountPlasticPellets;
    [SerializeField] TextMeshProUGUI[] _amountListSellItem;
    bool _isOpen;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateAmountItemToolbar();
        StartCoroutine(ManagerInvetori.Instance.UpdateMoney(0));
    }

    public void UpdateAmountItemToolbar()
    {
        for (int i = 0; i < ManagerInvetori.Instance._inventoriSlot.Length; i++)
        {
            _amountRubbish[i].text = ManagerInvetori.Instance._inventoriSlot[i]._amountItem.ToString();
        }
        _amountPlasticPellets.text = ManagerInvetori.Instance._bijiPlastik._amountItem.ToString();
        for (int i = 0; i < ManagerInvetori.Instance._listItem.Count; i++)
        {
            _amountListSellItem[i].text = ManagerInvetori.Instance._listItem[i]._amountItem.ToString();
        }
    }

    public void ShowSellButton(Seller seller, int index)
    {
        _buttonSeller[index].DOAnchorPosX(200, 1);

        SellerButtonReference sellerButtonReference = _buttonSeller[index].GetComponent<SellerButtonReference>();
        sellerButtonReference._namaBarang.text = seller._nameItem.ToString();
        sellerButtonReference._jumlahBarang.text = seller._amountItem.ToString();
        sellerButtonReference._hargaJualBarang.text = seller._priceItem.ToString("N0");
    }

    public void HideSellButton(int index)
    {
        _buttonSeller[index].DOAnchorPosX(675, 1);
    }

    public void OpenToolbar()
    {
        if (!_isOpen)
        {
            _toolbarObject.DOAnchorPosY(0, 1);
            _isOpen = true;
        }
        else
        {
            _toolbarObject.DOAnchorPosY(-150, 1);
            _isOpen = false;
        }
    }

    public void Option() => Time.timeScale = 0;

    public void Resume() => Time.timeScale = 1;
}
