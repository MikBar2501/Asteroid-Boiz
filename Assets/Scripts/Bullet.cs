using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MovableObject
{
    protected Vector3 dirVector = new Vector3(0,0,0);

    public float timeToDestroy;

    public override void Initialize() {
        base.Initialize();
        base.directionVector = dirVector;
        base.PlaySound();
    }

    public void SetDirectionVector(Vector3 direction) {
            dirVector = direction;
        
    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        //collisionActions.Add(ObjType.Bullet, new Action.ActionDestroy());
        collisionActions.Add(ObjType.Asteroid, new Action.ActionDemage().Set(1));
        Invoke("Death",timeToDestroy);
    }
}
