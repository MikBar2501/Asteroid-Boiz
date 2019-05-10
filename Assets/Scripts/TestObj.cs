using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObj : Object
{
   

    // Update is called once per frame
    void Update()
    {
        float angle = Input.GetAxis("Horizontal");

        if(Input.GetAxis("Vertical") > 0) {
            Move();
        } 

        Rotation(angle);
        if(isTeleporting){
            Teleportation();
        }
        
    }
}
