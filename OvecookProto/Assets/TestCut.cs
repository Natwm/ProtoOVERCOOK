using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCut : MonoBehaviour
{
    public Cuttable[] test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (Cuttable item in test)
            {
                item.Cut();
            }
        }
    }
}
