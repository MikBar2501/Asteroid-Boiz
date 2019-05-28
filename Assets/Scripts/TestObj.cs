using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObj : MovableObject
{

    public Vector3 dirVec;
    public override void Initialize() {
        base.directionVector = dirVec;
    }

    public override void Move() {
         base.directionVector = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
         transform.position += directionVector.normalized * speed * Time.deltaTime;
    }
}
