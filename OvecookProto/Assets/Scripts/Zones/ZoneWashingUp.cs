using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWashingUp : ZoneController
{
    public override void OnDrop(Droppable droppable)
    {
        //if(droppable.GetComponent<Washable>())
            base.OnDrop(droppable);
    }
    
    public override void Use()
    {
        //_droppable?.GetComponent<Washable>()?.Wash();
    }
}
