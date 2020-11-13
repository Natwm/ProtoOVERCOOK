using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePlacheADecouper : ZoneController
{
    public override void OnDrop(GameObject droppable)
    {
        //if(droppable.GetComponnent<Washable>())
            base.OnDrop(droppable);
    }
    
    public override void Use()
    {
        //_droppable?.GetComponnent<Washable>()?.Wash();
    }
}
