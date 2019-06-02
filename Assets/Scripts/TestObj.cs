using System.Collections;
using System.Collections.Generic;
using Action;
using UnityEngine;
using ObjectsCreator;

public class TestObj : MovableObject
{

    public Vector3 dirVec;
    ResourcesObjectsCreator objectsCreator;

    public override void Initialize() {
        base.Initialize();
        base.directionVector = dirVec;

        objectsCreator = new ResourcesObjectsCreator(1);
    }

    public override void Move() {
        
        if(Input.GetButtonDown("Fire1")) {
            Action();
        }
        
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            base.directionVector = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
            dirVec = base.directionVector;
            transform.position += directionVector.normalized * speed * Time.deltaTime;
        } 

        
    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        collisionActions.Add(ObjType.Asteroid, new Action.ActionDestroy());
        collisionActions.Add(ObjType.Player, new Action.ActionDemage().Set(1));
    }

    public void Action() {
        GameObject newBullet = objectsCreator.Create();
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;

        newBullet.GetComponent<Bullet>().SetDirectionVector(base.directionVector);
    }
}
