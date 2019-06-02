using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MovableObject
{
    public override void Initialize()
    {
        base.Initialize();
        GameManager.instance.AddLevelObject(gameObject);
        directionVector = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        collisionActions.Add(ObjType.Bullet, new Action.ActionDestroy());
        collisionActions.Add(ObjType.Player, new Action.ActionDestroy());
    }

    private void OnDestroy()
    {       
        GameManager.instance.Invoke("CheckForLevelEnd", 0.5f);
    }
}
