using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public Transform dropPosition;
    protected Droppable _droppable;

    public virtual void OnDrop(Droppable droppable){
        if(this._droppable == null)
        {
            _droppable = droppable;
            _droppable.transform.SetParent(transform);
            _droppable.transform.position = dropPosition.position;
            
        }
    }

    public virtual Droppable OnPick()
    {
        if(this._droppable != null)
        {
            Droppable droppable = _droppable;
            droppable.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            droppable.transform.localPosition = Vector3.forward;
            _droppable = null;
            return droppable;
        }

        return null;
    }

    public virtual void Use() {}
}
