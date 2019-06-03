using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MovableObject
{

    ObjectsCreator.ResourcesObjectsCreator objectsCreator;
    public int asteroidLevel;
    public AsteroidValues stats;
    public override void Initialize()
    {
        base.Initialize();
        base.directionVector = new Vector3(Random.value, Random.value, 0);
        base.angle = Random.value * 10;
        base.speed = Random.Range(0.8f, 2f);
        if (objectsCreator == null)
            objectsCreator = new ObjectsCreator.ResourcesObjectsCreator(stats.baseAsteroidID);
        SetStats(stats);

    }

    protected override void ImplementCollisions()
    {
        base.ImplementCollisions();

        collisionActions.Add(ObjType.Player, new Action.ActionDestroy());
        collisionActions.Add(ObjType.Bullet, new Action.ActionDemage().Set(1));


    }
    public override void Death()
    {
        // base.Death();
        Destroy(gameObject);

    }

    public override void Demage(int dmg = 1)
    {
        base.health -= dmg;
        if (base.health <= 0)
            SplitOnDeath();
    }

    public void SplitOnDeath()
    {
        if (asteroidLevel > 0)
        {
            int spawnNb = Random.Range((int)stats.minMaxNumberOfNewAsteroidsCreated.x, (int)stats.minMaxNumberOfNewAsteroidsCreated.y);
            for (int i = 0; i < spawnNb; i++)
            {
                GameObject aster = objectsCreator.Create();
                aster.transform.position = this.transform.position;
                Asteroid asterScript = aster.GetComponent<Asteroid>();
                asterScript.asteroidLevel = asteroidLevel - 1;
                asterScript.SetStats(stats);
                //asterScript.directionVector = (asterScript.directionVector + (directionVector * stats.parentMomentum)) / (1 + stats.parentMomentum); 

            }

        }
        Destroy(gameObject);
    }

    public void SetStats(AsteroidValues stats)
    {
        base.speed = Random.Range(stats.minMaxSpeed.x, stats.minMaxSpeed.y);
        base.angle = Random.Range(stats.minMaxRotation.x, stats.minMaxRotation.y);
        base.health = stats.maxHealth;
        int maxPossibleAsteroidLvl = 0;
        if (stats.maxLevelOfAsteroid > stats.AsteroidSpriteList.Count - 1)
            maxPossibleAsteroidLvl = stats.maxLevelOfAsteroid;
        else
            maxPossibleAsteroidLvl = stats.AsteroidSpriteList.Count - 1;
        if (asteroidLevel > maxPossibleAsteroidLvl)
            asteroidLevel = maxPossibleAsteroidLvl;
        /*
        List<int> sameLvlAsteroid = new List<int>();
        for (int i = 0; i < stats.AsteroidLvlGrouping.Count; i++)
        {
            if (stats.AsteroidLvlGrouping[i] == asteroidLevel)
                sameLvlAsteroid.Add(i);
        }
        int choosenAsteroid = sameLvlAsteroid[(int)Random.Range(0, sameLvlAsteroid.Count - 1)];
        Debug.Log(choosenAsteroid);
                base.sprite = stats.AsteroidSpriteList[choosenAsteroid];
        gameObject.GetComponent<CircleCollider2D>().radius = stats.AsteroidRadiusList[choosenAsteroid];
        */
        base.sprite = stats.AsteroidSpriteList[asteroidLevel];
        gameObject.GetComponent<CircleCollider2D>().radius = stats.AsteroidRadiusList[asteroidLevel];
        objectsCreator = new ObjectsCreator.ResourcesObjectsCreator(stats.baseAsteroidID);
    }
}
