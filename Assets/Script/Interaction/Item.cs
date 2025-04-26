using UnityEngine;

public class Item : Interaction
{
    [SerializeField] string _nameItem;

    ManagerItem _manager;

    private void Start()
    {
        _manager = gameObject.GetComponentInParent<ManagerItem>();
    }

    public override void GetInteraction()
    {
        ManagerInvetori.Instance.GetInventoryItem(_nameItem);
        ManagerUI.Instance.UpdateAmountItemToolbar();
        _manager.GetRemoveItem();
        Destroy(gameObject);
    }
}