using System.Collections;
using System.Collections.Generic;
using Action;
using UnityEngine;

public class TestObj : MovableObject
{

    public Vector3 dirVec;
    public override void Initialize() {
        base.Initialize();
        base.directionVector = dirVec;
    }

    public override void Move() {
         base.directionVector = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
         transform.position += directionVector.normalized * speed * Time.deltaTime;
    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        collisionActions.Add(ObjType.Asteroid, new Action.ActionDestroy());
        collisionActions.Add(ObjType.Player, new Action.ActionDemage().Set(1));
    }
}
