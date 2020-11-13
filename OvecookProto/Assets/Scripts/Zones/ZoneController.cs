using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public Transform dropPosition;
    protected GameObject _droppable;

    public virtual void OnDrop(GameObject droppable){
        if(this._droppable == null)
        {
            _droppable = droppable;
            _droppable.transform.position = dropPosition.position;
        }
    }

    public virtual void Use() {}
}
