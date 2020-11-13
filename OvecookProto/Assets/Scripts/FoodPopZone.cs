using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPopZone : ZoneController
{
  public GameObject popResource;

  void Start()
  {
    
  }

 

    public override Droppable OnPick()
    {
        
        if (this._droppable != null)
        {

            Droppable droppable = _droppable;
            _droppable = null;
            return droppable;
        }
        GameObject avatar = GameObject.FindGameObjectWithTag("Player");
        // does avatar has food in hands ?
        //Droppable droppable = avatar.GetComponentInChildren<Droppable>();
        //if(droppable == null)

        GameObject resource = GameObject.Instantiate(popResource);
        resource.transform.SetParent(avatar.transform);
        resource.transform.localPosition = Vector3.forward;
        return resource.GetComponent<Droppable>();
    }


}
