using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTime : Interaction
{
    [SerializeField] GameObject _animationFaded;

    public override void GetInteraction()
    {
        Actions.OnDayChange();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        _animationFaded.SetActive(true);
        yield return new WaitForSeconds(1);
        _animationFaded.SetActive(false);
    }
}