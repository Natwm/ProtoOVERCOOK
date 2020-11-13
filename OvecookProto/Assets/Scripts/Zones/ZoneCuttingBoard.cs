using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCuttingBoard : ZoneController
{
    public override void Use()
    {
        _droppable?.GetComponent<Cuttable>()?.Cut();
    }
}
