using com.cyborgAssets.inspectorButtonPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTime : Interaction
{
    [ProButton] void Testing()
    {
        Actions.OnDayChange();
    }

    public override void GetInteraction()
    {
        Actions.OnDayChange();
    }
}