using UnityEngine;

public class ManagerItem : MonoBehaviour
{
    [SerializeField] GameObject _objectItem;
    [SerializeField] GameObject _isItAvailable;

    private void OnDisable()
    {
        Actions.OnDayChange -= GetInstantiate;
    }

    private void Start()
    {
        GetInstantiate();

        Actions.OnDayChange += GetInstantiate;
    }

    void GetInstantiate()
    {
        if (_isItAvailable == null) _isItAvailable = Instantiate(_objectItem, transform.position, Quaternion.identity, gameObject.transform);
    }

    public void GetRemoveItem()
    {
        _isItAvailable = null;
    }
}
