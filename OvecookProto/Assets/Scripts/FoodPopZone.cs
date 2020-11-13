using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPopZone : MonoBehaviour
{
  public GameObject popResource;

  void Start()
  {
    
  }

  void OnMouseDown()
  {
    OnInteraction();
  }

  public void OnInteraction()
  {
    GameObject avatar = GameObject.FindGameObjectWithTag("Player");
    // does avatar has food in hands ?
    //Droppable droppable = avatar.GetComponentInChildren<Droppable>();
    //if(droppable == null)
    
      GameObject resource = GameObject.Instantiate(popResource);
      resource.transform.SetParent(avatar.transform);
      resource.transform.localPosition = Vector3.forward;
    
  }
}
