using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public Transform dropPosition;
    private Gameobject _droppable;

    public void OnDrop(GameObject droppable){
        if(this._droppable == null)
        {
            _droppable = droppable;
            _droppable.transform.position = dropPosition;
        }
    }

    public virtual void Use() {}
}
