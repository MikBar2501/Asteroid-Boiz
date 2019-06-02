using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MovableObject
{
    ObjectsCreator.ResourcesObjectsCreator objectsCreator;
    public int asteroidLevel;

    public override void Initialize()
    {
        base.Initialize();
        base.directionVector = new Vector3( Random.value, Random.value, 0);
        base.angle = Random.value * 10;
        base.speed = Random.Range(0.8f, 2f);
        objectsCreator = new ObjectsCreator.ResourcesObjectsCreator(0);

    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        collisionActions.Add(ObjType.Player, new Action.ActionDemage().Set(1));
        collisionActions.Add(ObjType.Bullet, new Action.ActionDemage().Set(1));


    }
    ///*
    public override void Death()
    {
        base.Death();
        if (asteroidLevel > 0)
        {
            int spawnNb = Random.Range(0, 3);
            for (int i = 0; i < spawnNb; i++)
            {
                GameObject aster = objectsCreator.Create();
                aster.GetComponent<Asteroid>().asteroidLevel = asteroidLevel - 1;
                aster.transform.position = this.transform.position;
            }
            
        }
        Debug.Log("boop");
    }
    //*/
}
