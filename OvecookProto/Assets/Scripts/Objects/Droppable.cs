using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour
{
    public enum ObjectType {Tomate,Salade,Assiette};
    public ObjectType currentLegume;
    public GameObject inGameObject;
    
    // SET LE BON ALIMENT
    void Start()
    {
        GameObject tempObject = Resources.Load("Droppables/" + currentLegume.ToString()) as GameObject;
        inGameObject = Instantiate(tempObject, transform);
        tempObject.transform.localPosition = Vector3.zero;
        name = currentLegume.ToString();
    }

    
}
